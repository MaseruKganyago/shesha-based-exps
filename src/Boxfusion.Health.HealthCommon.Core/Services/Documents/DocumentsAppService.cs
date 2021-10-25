using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using Boxfusion.Health.HealthCommon.Core.Services.Documents.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Documents
{
	/// <summary>
	/// 
	/// </summary>
	[AbpAuthorize]
	[ApiVersion("1")]
	[Route("api/v{version:apiVersion}/Cdm/[controller]")]
	public class DocumentsAppService : CdmAppServiceBase, IDocumentsAppService
    {
		private readonly IDocumentCrudHelper _documentCrudHelper;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="documentCrudHelper"></param>
		public DocumentsAppService(
			IDocumentCrudHelper documentCrudHelper)
        {
			_documentCrudHelper = documentCrudHelper;

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="encounterId"></param>
		/// <param name="patientId"></param>
		/// <returns></returns>
		[HttpGet, Route("{encounterId}/encounters/{patientId}/patients")]
		public async Task<List<DocumentResponse>> GetByConsultationIdAsync(Guid encounterId, Guid patientId)
		{
			var documentResponses = await _documentCrudHelper.GetByConsultationIdAsync(encounterId, patientId);

			return documentResponses;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="patientId"></param>
		/// <param name="type"></param>
		/// <returns></returns>
		[HttpGet, Route("{patientId}/patients")]
		public async Task<List<DocumentResponse>> GetByConsultationTypeAsync(Guid patientId, int type)
		{
			var documentResponses = await _documentCrudHelper.GetByConsultationTypeAsync(patientId, type);

			return documentResponses;
		}
	}
}
