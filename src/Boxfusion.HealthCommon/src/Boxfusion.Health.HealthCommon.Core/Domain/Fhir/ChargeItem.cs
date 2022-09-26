using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.ChargeItem")]
	[Discriminator]
	public class ChargeItem: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual ChargeItem PartOf { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Code { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Subject { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Encounter ContextEncounter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? OccurenceStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? OccurenceEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation PerformingOrganization { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation RequestingOrganization { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation CostCenter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual long? QuantityValue { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string QuantityUoM { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal? FactorOverride { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual decimal? PriceOverride { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[StringLength(int.MaxValue)]
		public virtual string OverrideReason { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual PersonFhirBase Enterer { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? EnteredDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Guid ServiceId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string ServiceType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Medication ProductMedication { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirAccount Account { get; set; }
	}
}
