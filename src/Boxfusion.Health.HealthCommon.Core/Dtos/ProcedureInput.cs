using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Dtos
{
    [AutoMap(typeof(Procedure))]
    public class ProcedureInput : EntityDto<Guid>
    {
        public string ProcedureName { get; set; }
        public DateTime ProcedureDate { get; set; }
    }
}
