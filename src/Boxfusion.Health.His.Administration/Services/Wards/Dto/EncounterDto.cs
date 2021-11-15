using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
    [AutoMapFrom(typeof(Encounter))]
    public class EncounterDto : EntityDto<Guid>
    {
    }
}
