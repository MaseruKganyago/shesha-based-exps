using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Shesha.Domain.Attributes;
using Shesha.Enterprise.Accounts;
using System;

namespace Boxfusion.Health.Cdm.Domain.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.FhirAccount")]
	public class FhirAccount: FinancialTransaction
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
	}
}
