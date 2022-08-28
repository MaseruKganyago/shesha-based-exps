using Abp.Authorization;
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

namespace Boxfusion.Health.His.Houghton.Customisation.Services.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/Hough/[controller]")]
    public class HoughtonWardAdmissionsAppService : SheshaAppServiceBase
    {
        private readonly IRepository<WardAdmission, Guid> _wardAdmissionRepositiory;
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
        public HoughtonWardAdmissionsAppService(IRepository<WardAdmission, Guid> wardAdmissionRepositiory, IRepository<Condition, Guid> conditionRepository, IRepository<Diagnosis, Guid> diagnosisRepository, IRepository<Note, Guid> noteRepository)
        {
            _wardAdmissionRepositiory = wardAdmissionRepositiory;
            _conditionRepository = conditionRepository;
            _diagnosisRepository = diagnosisRepository;
            _noteRepository = noteRepository;

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

            input.Conditions.ForEach(async condition => { await createDiagnosis(condition, wardAdmissionEntity); });

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
            var wardAdmissionEntity = await _wardAdmissionRepositiory.UpdateAsync(ObjectMapper.Map<WardAdmission>(input));

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
