using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    public class VerifyIDAndCreateNewPatientInput 
    {
        public AddressInput Address { get; set; }
    }
}
