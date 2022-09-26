using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Boxfusion.Health.His.Common.Admissions;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.WardAdmissions
{
    [AutoMap(typeof(WardAdmission))]
    public class WardDischargeDto : EntityDto<Guid>
    {

        public DateTime? DischargeDate { get; set; }

        public string DischargeNotes { get; set; }

        public EntityWithDisplayNameDto<Guid?> Physician { get; set; }

        public long? SeparationType { get; set; }
    }
}
