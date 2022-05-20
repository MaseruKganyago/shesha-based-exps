using Abp.Application.Services;
using Boxfusion.Health.His.Admissions.Domain.Domain.Admissions.Dtos;
using Boxfusion.Health.His.Common;
using Microsoft.AspNetCore.Mvc;
using Shesha.DynamicEntities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAdmissionsAppService : IApplicationService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardAdmission, Guid>> AdmitPatientAsync(AdmissionInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardAdmission, Guid>> UpdateAdmissionAsync(AdmissionInput input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<DynamicDto<WardAdmission, Guid>> SeparatePatientAsync(SeparationDto input);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="admissionId"></param>
        /// <returns></returns>
        Task<DynamicDto<WardAdmission, Guid>> UndoSeparationAsync([FromRoute] Guid admissionId);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<AcceptOrRejectTransfersResponse> AcceptOrRejectTransfers(AcceptOrRejectTransfersInput input);
    }
}
