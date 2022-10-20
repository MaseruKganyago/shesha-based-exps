﻿using Abp.Authorization;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds;
using Boxfusion.Health.His.Common.Beds.BedFees.Enums;
using Boxfusion.Health.His.Common.Beds.BedOccupations;
using Boxfusion.Health.His.Common.ChargeItems;
using Boxfusion.Health.His.Common.Domain.Domain.ChargeItems.Enums;
using Boxfusion.Health.His.Common.Domain.Domain.Products;
using Boxfusion.Health.His.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Linq;
using Shesha;
using Shesha.AutoMapper.Dto;
using Shesha.Domain;
using Shesha.DynamicEntities.Dtos;
using Shesha.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.WardAdmissions
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class WardAdmissionsAppService : SheshaAppServiceBase
	{
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
        private readonly IRepository<HospitalAdmission, Guid> _hospitalAdmissionRepository;
        private readonly IRepository<Condition, Guid> _conditionRepository;
        private readonly IRepository<Diagnosis, Guid> _diagnosisRepository;
        private readonly IRepository<Note, Guid> _noteRepository;
        private readonly BedOccupationManager _bedOccupationManager;
		private readonly HisChargeItemsManager _chargeItemManager;
		private readonly IRepository<Bed, Guid> _bedRepository;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="wardAdmissionRepositiory"></param>
		/// <param name="conditionRepository"></param>
		/// <param name="diagnosisRepository"></param>
		/// <param name="noteRepository"></param>
		/// <param name="hospitalAdmissionRepository"></param>
		/// <param name="hisChargeItemManager"></param>
		/// <param name="bedRepository"></param>
		/// <param name="bedOccupationManager"></param>
		/// <param name="chargeItemManager"></param>
		public WardAdmissionsAppService(IRepository<WardAdmission, Guid> wardAdmissionRepositiory, 
            IRepository<Condition, Guid> conditionRepository, 
            IRepository<Diagnosis, Guid> diagnosisRepository, 
            IRepository<Note, Guid> noteRepository,
			IRepository<HospitalAdmission, Guid> hospitalAdmissionRepository,
			HisChargeItemsManager hisChargeItemManager,
			IRepository<Bed, Guid> bedRepository,
			BedOccupationManager bedOccupationManager,
			HisChargeItemsManager chargeItemManager)
        {
            _wardAdmissionRepositiory = wardAdmissionRepositiory;
            _conditionRepository = conditionRepository;
            _diagnosisRepository = diagnosisRepository;
            _noteRepository = noteRepository;
            _hospitalAdmissionRepository = hospitalAdmissionRepository;
            _bedOccupationManager = bedOccupationManager;
            _chargeItemManager = chargeItemManager;
            _bedRepository = bedRepository;
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("AdmitPatient")]
        public async Task<DynamicDto<WardAdmission, Guid>> AdmitPatientAsync(WardAdmissionsDto input)
        {
            var wardAdmissionEntity = await _wardAdmissionRepositiory.InsertAsync(ObjectMapper.Map<WardAdmission>(input));

            if (input.Conditions is not null && input.Conditions.Any())
            {
                var tasks = new List<Task>();
				input.Conditions.ForEach(condition => tasks.Add(createDiagnosis(condition, wardAdmissionEntity)));

                await Task.WhenAll(tasks);
			}

            var note = new Note()
            {
                NoteText = input.AdmissionNotes,
                OwnerId = wardAdmissionEntity.Id.ToString(),
                OwnerType = wardAdmissionEntity.GetTypeShortAlias(),
                Category = (int)RefListHisNoteType.admission
            };
            await _noteRepository.InsertAsync(note);

			//Create new chargedItem and bedOccupation for admission into ward
			var chargeItem = await CreateWardAdmissionChargeItem(wardAdmissionEntity);

			var newBedFee = new BedOccupation()
			{
				StartDate = wardAdmissionEntity.StartDateTime,
				WardAdmission = wardAdmissionEntity,
				Bed = wardAdmissionEntity.Bed,
				ChargeItem = chargeItem
			};
			await _bedOccupationManager.CreateBedOccupationAsync(newBedFee);

			return await MapToDynamicDtoAsync<WardAdmission, Guid>(wardAdmissionEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("DischargePatient")]
        public async Task<DynamicDto<WardAdmission, Guid>> DischargePatientAsync(WardDischargeDto input)
        {
            //Discharge patient from ward
            var currentAdmission = await _wardAdmissionRepositiory.GetAsync(input.Id);
			ObjectMapper.Map(input, currentAdmission);

            var wardAdmissionEntity = await _wardAdmissionRepositiory.UpdateAsync(currentAdmission);
            
            //Discharge patient from hospital
            var hospitalAdmission = await SaveOrUpdateEntityAsync<HospitalAdmission>(wardAdmissionEntity.PartOf.Id, async item => 
            {
                ObjectMapper.Map(input, item);
            });

			var note = new Note()
            {
                NoteText = input.DischargeNotes,
                OwnerId = wardAdmissionEntity.Id.ToString(),
                OwnerType = wardAdmissionEntity.GetTypeShortAlias(),
                Category = (int)RefListHisNoteType.discharge
            };
            await _noteRepository.InsertAsync(note);

            //Close bedOccupation on patient discharge
            var bedOccupation = await _bedOccupationManager.repository()
                                           .FirstOrDefaultAsync(a => a.WardAdmission.Id == wardAdmissionEntity.Id &&
                                            a.Status == RefListBedOccupationStatus.Open);

            await _bedOccupationManager.CloseBedOccupationAsync(bedOccupation);

			return await MapToDynamicDtoAsync<WardAdmission, Guid>(wardAdmissionEntity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hospitalAdmissionId"></param>
        /// <returns></returns>
        [HttpGet, Route("[action]")]
        public async Task<WardDischargeDto> GetDischargeDetails(Guid hospitalAdmissionId)
        {
            var wardAdmissions = await _wardAdmissionRepositiory.GetAllListAsync(a => a.PartOf.Id == hospitalAdmissionId);
            wardAdmissions.OrderByDescending(a => a.EndDateTime);

            var admission = wardAdmissions.FirstOrDefault();

            var note = await _noteRepository.FirstOrDefaultAsync(a => a.OwnerId == admission.Id.ToString()
                                            && a.Category == (int)RefListHisNoteType.discharge);


            var result = new WardDischargeDto()
            {
                DischargeDate = admission.EndDateTime,
                DischargeNotes = note.NoteText,
                Physician = new EntityWithDisplayNameDto<Guid?>(admission.Performer?.Id, admission.Performer?.FullName),
				SeparationType = (long?)admission.SeparationType,
			};

            return result;
		}

		private async Task<HisChargeItem> CreateWardAdmissionChargeItem(WardAdmission wardAdmissionEntity)
		{
			var bedList = await _bedRepository.GetAllIncluding(a => a.BedType)
											  .Where(a => a.Id == wardAdmissionEntity.Bed.Id).ToListAsync();
			var bed = bedList.FirstOrDefault();

			var productCode = await ProductsHelper.GetProductCode(bed.BedType.Id);

			var chargeItem = new HisChargeItem()
			{
				Subject = wardAdmissionEntity.Subject,
				ContextEncounter = wardAdmissionEntity.PartOf,
				ServiceId = wardAdmissionEntity.Id,
				ServiceType = wardAdmissionEntity.GetTypeShortAlias(),
				Code = productCode
            };

			var charge = await _chargeItemManager.CreateChargeItemAsync(chargeItem);

			return charge;
		}

		private async Task createDiagnosis(Guid conditionId, WardAdmission wardAdmissionEntity)
        {
            var condition = _conditionRepository.Get(conditionId);

            var diagnosis = new Diagnosis()
            {
                Condition = condition,
                OwnerId = wardAdmissionEntity.Id.ToString(),
                OwnerType = wardAdmissionEntity.GetTypeShortAlias(),
                Use = (int?)RefListEncounterDiagnosisRoles.AD
            };
            
            await _diagnosisRepository.InsertAsync(diagnosis);
        }
    }
}