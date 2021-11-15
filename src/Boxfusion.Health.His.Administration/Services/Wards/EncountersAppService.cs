using Abp.Application.Services.Dto;
using domain = Boxfusion.Health.Domain.Domain;
using Shesha;
using System;
using System.Collections.Generic;
using System.Text;
using fhir = Hl7.Fhir.Model;
using Abp.Authorization;
using Microsoft.AspNetCore.Mvc;
using Abp.Domain.Repositories;
using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;

namespace Boxfusion.Health.His.Admissions.Services.Admissions
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/fhir/[controller]")]
    public class EncountersAppService: SheshaCrudServiceBase<domain.Encounter, EncounterDto, Guid, PagedAndSortedResultRequestDto, EncounterDto, EncounterDto>, IEncountersAppService
    {
        public EncountersAppService(
            IRepository<domain.Encounter, Guid> repository
            ) : base(repository)
        {

        }


    }
}
