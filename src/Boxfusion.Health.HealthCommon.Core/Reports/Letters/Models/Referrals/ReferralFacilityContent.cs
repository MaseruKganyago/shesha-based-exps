using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper;
using Shesha.AutoMapper.Dto;
using Shesha.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.Referrals
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(ReferralServiceRequest))]
    public class ReferralFacilityContent 
    {
        private ReferralFacilityContent()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        public string HealthCareProvider { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string HPCSANumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DispensaryNumber { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PhysicalAddress { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ContactDetail { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string PatientName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string DateOfBirth { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string EvaluationLocation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReferralFacility { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Speciality { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReceivingPractitioner { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReferralReason { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AuthoredOn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Comment { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string QualificationIssuerName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private RefListQualificationCodes CodeLkp { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string QualificationName => UtilityHelper.GetRefListItemText("Fhir", "QualificationCodes", (int)this.CodeLkp);
        /// <summary>
        /// 
        /// </summary>
        public string PractitionerRole { get; set; }
    }
}
