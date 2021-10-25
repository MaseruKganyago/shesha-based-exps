using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Dtos.BackBoneElements;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class VerifyIDAndCreateNewPatientInput 
    {
        /// <summary>
        /// 
        /// </summary>
        public CdmAddressInput Address { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public IFormFile Image { get; set; }
    }
}
