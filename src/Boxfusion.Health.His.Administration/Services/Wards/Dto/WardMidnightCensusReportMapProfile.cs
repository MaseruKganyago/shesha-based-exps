using Boxfusion.Health.His.Admissions.Services.Admissions.Dto;
using Boxfusion.Health.His.Domain.Domain;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Services.Wards.Dto
{
    /// <summary>
    /// 
    /// </summary>
    public class WardMidnightCensusReportMapProfile : ShaProfile
    {
        /// <summary>
        /// 
        /// </summary>
        public WardMidnightCensusReportMapProfile()
        {

            CreateMap<WardMidnightCensusReport, WardMidnightCensusReportResponse>()
                .ForMember(c => c.ApprovedBy, options => options.MapFrom(c => c.ApprovedBy != null ? new EntityWithDisplayNameDto<Guid?>(c.ApprovedBy.Id, c.ApprovedBy.FullName) : null))
                .ForMember(c => c.ApprovedBy2, options => options.MapFrom(c => c.ApprovedBy2 != null ? new EntityWithDisplayNameDto<Guid?>(c.ApprovedBy2.Id, c.ApprovedBy2.FullName) : null))
                .ForMember(c => c.RejectedBy, options => options.MapFrom(c => c.RejectedBy != null ? new EntityWithDisplayNameDto<Guid?>(c.RejectedBy.Id, c.RejectedBy.FullName) : null))
                .ForMember(c => c.Ward, options => options.MapFrom(c => c.Ward != null ? new EntityWithDisplayNameDto<Guid?>(c.Ward.Id, c.Ward.Name) : null))
                .MapReferenceListValuesToDto();

            CreateMap<DailyStats, WardMidnightCensusReport>()
                .ForMember(c => c.MidnightCount, options => options.MapFrom(r => r.MidnightCount))
                .ForMember(c => c.TotalAdmittedPatients, opt => opt.MapFrom(r => r.TotalAdmittedPatients))
                .ForMember(c => c.TotalSeparatedPatients, opt => opt.MapFrom(r => r.TotalSeparatedPatients))
                .ForMember(c => c.TotalBedAvailability, opt => opt.MapFrom(r => r.TotalBedAvailability))
                .ForMember(c => c.NumBedsInWard, opt => opt.MapFrom(r => r.TotalBedInWard))
                .ForMember(c => c.AverageBedAvailability, opt => opt.MapFrom(r => r.AverageBedAvailability))
                ;
        }
    }
}
