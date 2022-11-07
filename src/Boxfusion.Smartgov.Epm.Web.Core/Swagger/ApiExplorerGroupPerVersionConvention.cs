using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Boxfusion.Smartgov.Epm.Swagger
{
    public class ApiExplorerGroupPerVersionConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ApiExplorer.GroupName = controller.ControllerType.Name;
        }
    }
}
