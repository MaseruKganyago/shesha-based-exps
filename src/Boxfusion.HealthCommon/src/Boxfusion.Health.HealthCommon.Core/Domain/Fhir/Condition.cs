using Abp.Domain.Entities.Auditing;
using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
    /// <summary>
    /// 
    /// </summary>
    [Entity(TypeShortAlias = "HealthCommon.Core.Condition")]
    public class Condition : FullAuditedEntity<Guid>
    {
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListConditionClinicalStatus? ClinicalStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListConditionVerificationStatus? VerificationStatus { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "ConditionCategory")]
        public virtual RefListConditionCategory? Category { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual RefListConditionSeverity? Severity { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MultiValueReferenceList("Fhir", "BodySite")]
        public virtual int? BodySite { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual Patient Subject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Encounter FhirEncounter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual ConsultationEncounter Encounter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual HospitalisationEncounter HospitalisationEncounter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? OnsetDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int OnsetAge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? OnsetPeriodStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? OnsetPeriodEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal OnsetRangeLow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal OnsetRangeHigh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string OnsetString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? AbatementDateTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual int AbatementAge { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? AbatementPeriodStart { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? AbatementPeriodEnd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal AbatementRangeLow { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual decimal AbatementRangeHigh { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual string AbatementString { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual DateTime? RecordedDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase Recorder { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public virtual PersonFhirBase Asserter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string DisplayName => conditions().Result;

		private async Task<string> conditions()
		{
			var repository = StaticContext.IocManager.Resolve<IRepository<ConditionIcdTenCode, Guid>>();
            var assignments = await repository.GetAllListAsync(a => a.Condition.Id == Id);

            var textList = new List<string>();
            assignments.ForEach(ass =>
            {
                textList.Add($"{ass.IcdTenCode.GroupCode} {ass.IcdTenCode.WHOFullDesc}");
            });

            return textList.Aggregate((a, b) => a + ',' + b);
        }
	}
}
