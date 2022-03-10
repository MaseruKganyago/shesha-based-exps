using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common
{
    /// <summary>
    /// Helper class to easily retrieve information related to the request context.
    /// </summary>
    public class RequestContextHelper
    {
        private const string CONTEXT_FACILITY_ID_HEADER_NAME = "boxhis-facilityId";
        private readonly IHttpContextAccessor _httpContextAccessor;


        public static HttpContext HttpContext
        {
            get
            {
                return Abp.Dependency.IocManager.Instance.Resolve<IHttpContextAccessor>().HttpContext;
            }
        }

            
        /// <summary>
        /// Returns true if a  ContextFacilityId (i.e. the Facility from which the user is making requests for) has been provided.
        /// </summary>
        public static bool HasFacilityId
        {
            get
            {
                return true;        //TODO: TEMPORARILY FAKING NOW
                var stringContextFacilityId = HttpContext.Request.Headers[CONTEXT_FACILITY_ID_HEADER_NAME];
                return !string.IsNullOrEmpty(stringContextFacilityId);
            }
        }

        /// <summary>
        /// Returns the Id of the Context Facility (i.e. the Facility from which the user is making requests for)
        /// </summary>
        public static Guid FacilityId
        {
            get
            {
                if (string.IsNullOrEmpty(HttpContext.Request.Headers[CONTEXT_FACILITY_ID_HEADER_NAME]))
                    return Guid.Parse("0CDAD6B0-A3B2-4CF6-9B7D-238D753F0657");     //TODO:NOW REMOVE ONCE FACILITY IS GETTING PAST (Rob's Ferreira Hospital)


                var stringContextFacilityId = HttpContext.Request.Headers[CONTEXT_FACILITY_ID_HEADER_NAME];

                return Guid.Parse(stringContextFacilityId);
            }
        }
    }
}
