using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos.Fhir
{
	/// <summary>
	/// 
	/// </summary>
	[AutoMap(typeof(DocumentReference))]
	public class DocumentReferenceResponse: EntityDto<Guid>
	{
		/// <summary>
		/// 
		/// </summary>
		public string MasterIdentifier { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Identifier { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Status { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto DocStatus { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto Type { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public List<ReferenceListItemValueDto> Category { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SubjectOwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string SubjectOwnerType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? Date { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AuthorOwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string AuthorOwnerType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid> Custodian { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string Description { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto SecurityLabel { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ContextEncounterOwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ContextEnounterOwnerType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto ContextEvent { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? ContextPeriodStart { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public DateTime? ContextPeriodEnd { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto ContextFacilityType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ReferenceListItemValueDto ContextPracticeSetting { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public EntityWithDisplayNameDto<Guid?> ContextSourcePatientInfo { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ContextRelatedOwnerId { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public string ContextRelatedOwnerType { get; set; }

		/// <summary>
		/// 
		/// </summary>
		public ContentResponse Content { get; set; }
	}
}
