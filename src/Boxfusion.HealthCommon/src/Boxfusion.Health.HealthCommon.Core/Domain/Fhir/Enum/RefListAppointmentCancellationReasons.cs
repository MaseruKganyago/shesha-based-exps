using Shesha.Domain.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Boxfusion.Health.HealthCommon.Core.Domain.Fhir.Enum
{
    /// <summary>
    /// /
    /// </summary>
    [ReferenceList("Fhir", "CancellationReasons")]
    public enum RefListAppointmentCancellationReasons: long
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Patient")]
        pat = 1,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Canceled via automated reminder system")]
        patCrs = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Canceled via Patient Portal")]
        patCpp = 3,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Deceased")]
        patDec = 4,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Feeling Better")]
        patFb = 5,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Lack of Transportation")]
        patLt = 6,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Member Terminated")]
        patMt = 7,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Moved")]
        patMv = 8,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Pregnant")]
        patPreg = 9,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Scheduled from Wait List")]
        patSwl = 10,

        /// <summary>
        /// 
        /// </summary>
        [Description("Patient: Unhappy/Changed Provider")]
        patUcp = 11,

        /// <summary>
        /// 
        /// </summary>
        [Description("Provider")]
        prov = 12,

        /// <summary>
        /// 
        /// </summary>
        [Description("Provider: Personal")]
        provPers = 13,

        /// <summary>
        /// 
        /// </summary>
        [Description("Provider: Discharged")]
        provDch = 14,

        /// <summary>
        /// 
        /// </summary>
        [Description("Provider: Edu/Meeting")]
        provEdu = 15,

        /// <summary>
        /// 
        /// </summary>
        [Description("Provider: Hospitalized")]
        provHosp = 16,

        /// <summary>
        /// 
        /// </summary>
        [Description("Provider: Labs Out of Acceptable Range")]
        provLabs = 17,

        /// <summary>
        /// 
        /// </summary>
        [Description("Provider: MRI Screening Form Marked Do Not Proceed")]
        provMri = 18,

        /// <summary>
        /// 
        /// </summary>
        [Description("Provider: Oncology Treatment Plan Changes")]
        provOnc = 19,

        /// <summary>
        /// 
        /// </summary>
        [Description("Equipment Maintenance/Repair")]
        maint = 20,

        /// <summary>
        /// 
        /// </summary>
        [Description("Prep/Med Incomplete")]
        medsInc = 21,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other")]
        other = 22,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: CMS Therapy Cap Service Not Authorized")]
        othCms = 23,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: Error")]
        othErr = 24,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: Financial")]
        othFin = 25,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: Improper IV Access/Infiltrate IV")]
        othIv = 26,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: No Interpreter Available")]
        othInt = 27,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: Prep/Med/Results Unavailable")]
        othMu = 28,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: Room/Resource Maintenance")]
        othRoom = 29,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: Schedule Order Error")]
        othOerr = 30,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: Silent Walk In Error")]
        othSwie = 31,

        /// <summary>
        /// 
        /// </summary>
        [Description("Other: Weather")]
        othWeath = 32,
    }
}
