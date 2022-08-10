using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.Cdm.Domain.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.Cdm.Domain.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Coverage")]
	public class Coverage: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "CoverageStatus")]
		public virtual long? Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "CoverageType")]
		public virtual long? Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual PersonFhirBase Subscriber { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string SubscriberId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Beneficiary { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Dependent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "CoverageRelationshipType")]
		public virtual long? Relationship { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime PeriodStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime PeriodEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation PayorOrganisation { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual PersonFhirBase PayorPerson { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Class Class { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual int Order { get; set; }
	}
}
