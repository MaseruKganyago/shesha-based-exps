using System;
using Abp.Dependency;
using Microsoft.AspNetCore.Mvc;
using Shesha.Authorization.Users;
using Shesha.Web.DataTable;

namespace Boxfusion.Health.His.Controllers
{
    // note: temporary declared locally in the project, to be moved to the Shesha later
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersAdministrationController : ControllerBase, ITransientDependency
    {
        public static DataTableConfig IndexTable()
        {
            var table = new DataTableConfig<User, Int64>("Users_Index");

            table.AddProperty(e => e.UserName, c => c.SortAscending());
            table.AddProperty(e => e.Name);
            table.AddProperty(e => e.Surname);
            table.AddProperty(e => e.EmailAddress);
            table.AddProperty(e => e.PhoneNumber);
            table.AddProperty(e => e.CreatorUser);
            table.AddProperty(e => e.CreatorUserId);
            table.AddProperty(e => e.CreationTime);
            table.AddProperty(e => e.IsActive);

            return table;
        }
    }
}
