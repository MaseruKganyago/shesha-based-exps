using System.Collections.Generic;
using Abp.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Boxfusion.Health.His.Web.Host.Swagger
{
    public class AbpAppServiceApiVersionSpecification : IApiControllerSpecification
    {
        public bool IsSatisfiedBy(ControllerModel controller)
        {
            var typeInfo = controller.ControllerType;
            var type = controller.ControllerType.AsType();
            if (!typeof(IApplicationService).IsAssignableFrom(type) ||
               !typeInfo.IsPublic || typeInfo.IsAbstract || typeInfo.IsGenericType)
            {
                return false;
            }
            if (!(controller.Attributes is List<object> attributes))
            {
                return false;
            }
            if (typeInfo.IsDefined(typeof(ApiVersionAttribute), false))
            {
                attributes.Add(new ApiVersionAttribute("1"));//Set default version
            }
            return true;
        }
    }
}
