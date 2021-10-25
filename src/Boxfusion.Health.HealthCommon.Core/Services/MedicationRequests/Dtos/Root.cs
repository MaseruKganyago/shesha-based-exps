using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public Products Products { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object DataError { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool IsDemoData { get; set; }
    }
}
