using Microsoft.AspNetCore.Http;
using Shesha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common
{
    /// <summary>
    /// To be used as the Base class for all AppServices
    /// </summary>
    public class HisAppServiceBase : SheshaAppServiceBase
    {
        private const string CONTEXT_FACILITY_ID_HEADER_NAME = "his-facilityId";
        private readonly IHttpContextAccessor _httpContextAccessor;

        /// <summary>
        /// Returns true if a  ContextFacilityId (i.e. the Facility from which the user is making requests for) has been provided.
        /// </summary>
        public bool HasContextFacilityId
        {
            get
            {
                return RequestContextHelper.HasFacilityId;
            }
        }

        /// <summary>
        /// Returns the Id of the Context Facility (i.e. the Facility from which the user is making requests for)
        /// </summary>
        public Guid ContextFacilityId
        {
            get
            {
                return RequestContextHelper.FacilityId;
            }
        }
        
    }
}
