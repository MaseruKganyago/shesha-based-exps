using Hangfire.Dashboard;
using Shesha.Authorization;

namespace Boxfusion.Smartgov.Epm.Hangfire
{
    /// <summary>
    /// Hangfire authorization filter
    /// </summary>
    public class HangfireAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            return context.GetHttpContext().GetUsernameFromJwtToken()?.Trim().ToLower() == "admin";
        }
    }
}
