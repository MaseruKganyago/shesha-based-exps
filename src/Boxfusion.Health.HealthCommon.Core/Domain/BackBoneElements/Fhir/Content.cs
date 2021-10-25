using Abp.Domain.Entities.Auditing;
using Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Shesha.Domain;
using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.BackBoneElements.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[Entity(TypeShortAlias = "HealthCommon.Core.Content")]
	public class Content: FullAuditedEntity<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public virtual string OwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual string OwnerType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual RefListDocumentReferenceFormatCodeSets Format { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public virtual StoredFile Attachment { get; set; } 
	}
}
