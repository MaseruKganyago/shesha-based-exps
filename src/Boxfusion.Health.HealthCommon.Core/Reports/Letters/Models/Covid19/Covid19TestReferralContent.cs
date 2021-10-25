using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm.Enum;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum;
using Boxfusion.Health.HealthCommon.Core.Helpers;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.Covid19
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(DiagnosticTestServiceRequest))]
    public class Covid19TestReferralContent
    {
        /// <summary>
        /// 
        /// </summary>
        private Covid19TestReferralContent()
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
        public EntityWithDisplayNameDto<Guid?> Encounter { get; set; }


        /// <summary>
        /// 
        /// </summary>
        public string ExaminationType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ExamReason { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FacilityType { get; set; }

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
