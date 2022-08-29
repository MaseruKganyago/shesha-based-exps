using Boxfusion.Health.His.Common;
using Boxfusion.Health.His.Common.Admissions;
using Boxfusion.Health.His.Common.Beds;
using Boxfusion.Health.His.Common.Domain.Domain.Room;
using Boxfusion.Health.His.Common.Enums;
using Boxfusion.Health.His.Common.Patients;
using Shesha.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.WardAdmissions
{
    public class AdmissionsMapProfile: ShaProfile
    {
        public AdmissionsMapProfile()
        {
            CreateMap<WardAdmissionsDto, WardAdmission>()
                .ForMember(a => a.Subject, b => b.MapFrom(c => GetEntity<HisPatient>(c.Patient)))
                .ForMember(a => a.Ward, b => b.MapFrom(c => GetEntity<HisWard>(c.Ward.Id)))
                .ForMember(a => a.Room, b => b.MapFrom(c => GetEntity<Room>(c.Room.Id)))
                .ForMember(a => a.Bed, b => b.MapFrom(c => GetEntity<Bed>(c.Bed.Id)))
                .ForMember(a => a.StartDateTime, b => b.MapFrom(c => c.AdmissionDate))
                .ForMember(a => a.AdmissionStatus, b => b.MapFrom(c=> RefListAdmissionStatuses.admitted))
                .ForMember(a => a.PartOf, b => b.MapFrom(c=>GetEntity<HospitalAdmission>(c.PartOf)))
                .MapReferenceListValuesFromDto();

            CreateMap<WardDischargeDto, WardAdmission>()
                .ForMember(a => a.EndDateTime, b => b.MapFrom(c => c.DischargeDate))
                .ForMember(a => a.AdmissionStatus, b => b.MapFrom(c => RefListAdmissionStatuses.separated));
        }

    }
}
