﻿using Abp.Authorization;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Enums;
using Microsoft.AspNetCore.Mvc;
using Shesha;
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="wardAdmissionRepositiory"></param>
        /// <param name="conditionRepository"></param>
        /// <param name="diagnosisRepository"></param>
        /// <param name="noteRepository"></param>
        /// <param name="hospitalAdmissionRepository"></param>
        public WardAdmissionsAppService(IRepository<WardAdmission, Guid> wardAdmissionRepositiory, 
            IRepository<Condition, Guid> conditionRepository, 
            IRepository<Diagnosis, Guid> diagnosisRepository, 
            IRepository<Note, Guid> noteRepository,
			IRepository<HospitalAdmission, Guid> hospitalAdmissionRepository)
        {
            _wardAdmissionRepositiory = wardAdmissionRepositiory;
            _conditionRepository = conditionRepository;
            _diagnosisRepository = diagnosisRepository;
            _noteRepository = noteRepository;
            _hospitalAdmissionRepository = hospitalAdmissionRepository;


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
            var wardAdmissionEntity = await SaveOrUpdateEntityAsync<WardAdmission>(input.Id, async item => 
            {
                ObjectMapper.Map(input, item);
			});

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
            return await MapToDynamicDtoAsync<WardAdmission, Guid>(wardAdmissionEntity);
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
