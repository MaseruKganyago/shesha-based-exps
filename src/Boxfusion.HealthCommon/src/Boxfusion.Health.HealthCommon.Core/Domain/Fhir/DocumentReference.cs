using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.DocumentReference")]
	public class DocumentReference : FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string MasterIdentifier { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Identifier { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListDocumentReferenceStatuses Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListCompositionStatuses DocStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListDocumentTypeValueSets Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		[MultiValueReferenceList("Fhir", "DocumentClassValueSets")]
		public virtual RefListDocumentClassValueSets Category { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string SubjectOwnerId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual string SubjectOwnerType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual Patient Subject { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Practitioner Practitioner { get; set; }


		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? Date { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string AuthorOwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string AuthorOwnerType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual FhirOrganisation Custodian { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListSecurityLabels SecurityLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string ContextEncounterOwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string ContextEncounterOwnerType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListVersionThreeActCodes ContextEvent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ContextPeriodStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual DateTime? ContextPeriodEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListFacilityTypeCodeValueSets ContextFacilityType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListHealthcareServicec80PracticeCodes ContextPracticeSetting { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual Patient ContextSourcePatientInfo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string ContextRelatedOwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string ContextRelatedOwnerType { get; set; }
	}
}
