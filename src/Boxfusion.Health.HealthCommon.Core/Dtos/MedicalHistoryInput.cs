using Abp.Application.Services.Dto;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    public class MedicalHistoryInput: EntityDto<Guid>
    {
        public EntityWithDisplayNameDto<Guid?> Patient { get; set; }
        public List<ConditionInput> MedicalProblems { get; set; }
        public List<MedicationStatementInput> CurrentMedication { get; set; }
        public List<MedicationStatementInput> PastMedication { get; set; }
        public List<ProcedureInput> PastOperations { get; set; }
        public List<AllergyIntoleranceInput> Allergies { get; set; }
    }
}
