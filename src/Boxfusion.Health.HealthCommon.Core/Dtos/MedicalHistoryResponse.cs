using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    public class MedicalHistoryResponse: EntityDto<Guid> 
    {
        public EntityWithDisplayNameDto<Guid?> Patient { get; set; }

        public List<ConditionResponse> MedicalProblems { get; set; }

        public List<MedicationStatementResponse> CurrentMedication { get; set; }

        public List<MedicationStatementResponse> PastMedication { get; set; }

        public List<ProcedureResponse> PastOperations { get; set; }

        public List<AllergyIntoleranceResponse> Allergies { get; set; }
    }
}
