using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICdmSettings
    {
        /// <summary>
        /// 
        /// </summary>
        string CustomerKey { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string CustomerSecret { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string OrganisationIdentifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string FacilityIdentifier { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string AppCertificate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string AppId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string MedpraxUsername { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string MedpraxPassword { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string MedpraxBaseAddress { get; set; }
    }
}
