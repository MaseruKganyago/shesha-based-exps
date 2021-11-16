using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Reports.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class ReportMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public ReportMapProfile()
        {
            //ReportResponse
            CreateMap<WardAdmission, ReportResponseDto>()
                .ForMember(a => a.PatientId, opt => opt.MapFrom(r=>r.Subject.Id))
                 .ForMember(a => a.IdentityNumber, opt => opt.MapFrom(r => r.Subject.IdentityNumber))
                  .ForMember(a => a.AdminstrationDate, opt => opt.MapFrom(r => r.CreationTime))
                   .ForMember(a => a.AdmissionStatus, opt => opt.MapFrom(r => r.AdmissionStatus))
                    .ForMember(a => a.AdmissionType, opt => opt.MapFrom(r => r.AdmissionType))
                     .ForMember(a => a.DateOfBirth, opt => opt.MapFrom(r => r.Subject.DateOfBirth))
                     .ForMember(a => a.Gender, opt => opt.MapFrom(r => r.Subject.Gender))
                      .ForMember(a => a.Nationality, opt => opt.MapFrom(r => r.Subject.Nationality))
                       .ForMember(a => a.PatientName, opt => opt.MapFrom(r => r.Subject.FirstName))
                        .ForMember(a => a.PatientSurname, opt => opt.MapFrom(r => r.Subject.LastName))
                         .ForMember(a => a.Gender, opt => opt.MapFrom(r => r.Subject.Gender))
                           .ForMember(a => a.WardAdmissionNumber, opt => opt.MapFrom(b => b.WardAdmissionNumber));
                            // Speciality = r.SeparationDestinationWard.Speciality, TODO : Find speciality

            // HisPaient to ReportResponse
            CreateMap<HisPatient, ReportResponseDto>()
                .ForMember(a => a.PatientProvice, opt => opt.MapFrom(r => r.PatientProvince))
                 .ForMember(a => a.HospitalPatientNumber, opt => opt.MapFrom(r => r.HospitalPatientNumber))
                  .ForMember(a => a.IdentificationType, opt => opt.MapFrom(r => r.IdentificationType));
        }
    }
}
