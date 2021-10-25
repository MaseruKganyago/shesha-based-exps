using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class LoginResponse
    {
        /// <summary>
        /// 
        /// </summary>
        public string SessionToken { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int SystemUserId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime CreatedTimestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime ExpiryTimestamp { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object UserDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public object UserTime { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> Roles { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<object> Functions { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string TimeZoneID { get; set; }
    }
}
