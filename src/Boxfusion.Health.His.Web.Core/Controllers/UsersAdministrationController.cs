﻿using Abp.Dependency;
using Microsoft.AspNetCore.Mvc;

namespace Boxfusion.Health.His.Controllers
{
    // note: temporary declared locally in the project, to be moved to the Shesha later
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersAdministrationController : ControllerBase, ITransientDependency
    {
    }
}
