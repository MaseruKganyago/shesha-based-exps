using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.TempAdmissions.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(WardAdmission))]
    public class AdmissionInput : EntityDto<Guid>
    {

    }
}
