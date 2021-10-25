using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class ProductRequest
    {
        /// <summary>
        /// 
        /// </summary>
        public ProductRequest(string value)
        {
            PropertyName = "Name";
            Operation = "StartsWith";
            Value = $"{value}";
        }
        /// <summary>
        /// 
        /// </summary>
        public string PropertyName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Operation { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Value { get; set; }
    }
}
