using Boxfusion.Health.Cdm.Domain.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using Shesha.Enterprise.Accounts;
using System;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.FhirAccount")]
	public class FhirAccount: FinancialAccount
	{
		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "AccountStatus")]
		public virtual long? AccountStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[ReferenceList("Fhir", "AccountType")]
		public virtual long? AccountType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ServiceStartDate { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ServiceStartEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Coverage Coverage { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation Owner { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirAccount PartOf { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Encounter Encounter { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Patient Subject { get; set; }
	}
}
