using Abp.AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Domain.Cdm;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Reports.Letters.Models.eScripts
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(CdmMedicationRequest))]
    public class MedicationRequestContent
    {
        /// <summary>
        /// 
        /// </summary>
        public string MedicationName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string MedicationCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Dosage { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Route { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Frequency { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Duration { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Repeat { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Instruction { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Quantity { get; set; }
    }
}
