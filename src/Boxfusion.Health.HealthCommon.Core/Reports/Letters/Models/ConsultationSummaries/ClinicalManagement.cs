using Abp.Domain.Repositories;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using Boxfusion.Health.HealthCommon.Core.Domain.Fhir;
using System;
using System.Linq;

namespace Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.ConsultationSummaries
{
    /// <summary>
    /// 
    /// </summary>
    public class ClinicalManagement
    {
        /// <summary>
        /// 
        /// </summary>
        public ClinicalManagement( )
        {

        }


        /// <summary>
        /// 
        /// </summary>
        public string ChwServiceRequestMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReferToFacilityServiceRequestMessage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Covid19ServiceRequestMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string AmbulanceServiceRequestMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string ReferToPractitionerServiceRequestMessage { get; set; }
        ///// <summary>
        ///// 
        ///// </summary>
        //public string TeleHealthServiceRequestMessage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string SickNoteMessage { get; set; }
    }
}
