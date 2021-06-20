using Abp.Application.Services.Dto;
using domain = Boxfusion.Health.Domain.Domain;
using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Admissions.Dto
{
    [AutoMapFrom(typeof(domain.Encounter))]
    public class EncounterDto : EntityDto<Guid>
    {
    }
}
