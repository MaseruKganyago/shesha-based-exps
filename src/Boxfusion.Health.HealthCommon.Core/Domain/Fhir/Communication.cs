using Abp.Domain.Entities.Auditing;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir
{
	[Entity(TypeShortAlias = "HealthCommon.Core.Communication")]
	public class Communication: FullAuditedEntity<Guid>
	{
		public virtual string Identifier { get; set; }
		public virtual string BasedOnOwnerId { get; set; }
		public virtual string BasedOnOwnerType { get; set; }
		public virtual string PartOfOwnerId { get; set; }
		public virtual string PartOfOwnerType { get; set; }
		public virtual Communication InResponseTo { get; set; }
		[ReferenceList("Fhir", "EvantStatuses")]
		public virtual int? Status { get; set; }
		[ReferenceList("Fhir", "CommunicationNotDoneReasons")]
		public virtual int? StatusReason { get; set; }
		[ReferenceList("Fhir", "CommunicationCategories")]
		public virtual int? Category { get; set; }
		[ReferenceList("Fhir", "RequestPriosities")]
		public virtual int? Priority { get; set; }
		[MultiValueReferenceList("Fhir", "ParticipationModes")]
		public virtual int? Medium { get; set; }
		public virtual Patient Subject { get; set; }
		[ReferenceList("Fhir", "CommunicationTopics")]
		public virtual int? Topic { get; set; }
		public virtual string AboutOwnerId { get; set; }
		public virtual string AboutOwnerType { get; set; }
		public virtual Encounter Encounter { get; set; }
		public virtual DateTime? Sent { get; set; }
		public virtual DateTime? Recieved { get; set; }
		public virtual string RecipientOwnerId { get; set; }
		public virtual string RecipientOwnerType { get; set; }
		public virtual string SenderOwnerId { get; set; }
		public virtual string SenderOwnerType { get; set; }
		[ReferenceList("Fhir", "ConditionProblemDiagnosisCodes")]
		public virtual int? ReasonCode { get; set; }
		public virtual string ReasonReferenceOwnerId { get; set; }
		public virtual string ReasonReferenceOwnerType { get; set; }
	}
}
