using Boxfusion.Health.HealthCommon.Core.Dtos.Cdm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.Documents.Helpers
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDocumentCrudHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="encounterId"></param>
        /// <param name="patientId"></param>
        /// <returns></returns>
        Task<List<DocumentResponse>> GetByConsultationIdAsync(Guid encounterId, Guid patientId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<List<DocumentResponse>> GetByConsultationTypeAsync(Guid patientId, int type);
    }
}
