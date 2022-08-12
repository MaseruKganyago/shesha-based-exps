using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Shesha.Domain.Attributes;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// 
    /// </summary>
    [ReferenceList("Fhir", "AppointmentReasonCodes")]
    public enum RefListAppointmentReasonCodes: long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("A routine check-up, such as an annual physical")]
        CHECKUP = 1,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Emergency appointment")]
        EMERGENCY = 2,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("A follow up visit from a previous appointment")]
        FOLLOWUP = 3,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("Routine appointment - default if not valued")]
        ROUTINE = 4,
        
        /// <summary>
        /// 
        /// </summary>
        [Description("A previously unscheduled walk-in visit")]
        WALKIN = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Referral")]
        REFERRAL = 10

    }
}
