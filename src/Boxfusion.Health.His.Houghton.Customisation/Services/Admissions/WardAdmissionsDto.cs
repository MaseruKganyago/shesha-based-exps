using Abp.Application.Services.Dto;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Houghton.Customisation.Services.Admissions
{
    public class WardAdmissionsDto : EntityDto<Guid>
    {
        public Guid Patient { get; set; }

        public EntityWithDisplayNameDto<Guid> Ward { get; set; }

        public EntityWithDisplayNameDto<Guid> Room { get; set; }

        public EntityWithDisplayNameDto<Guid> Bed { get; set; }

        public DateTime AdmissionDate { get; set; }

        public ReferenceListItemValueDto AdmissionType { get; set; }

        public  List<Guid> Conditions { get; set; }

        public string AdmissionNotes { get; set; }

        public Guid PartOf { get; set; }
    }
}
