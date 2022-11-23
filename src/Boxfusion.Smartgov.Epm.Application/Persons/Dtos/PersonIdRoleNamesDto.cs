using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Smartgov.Epm.Persons.Dtos
{
	public class PersonIdRoleNamesDto: EntityDto<Guid>
	{
		public List<string> Roles { get; set; }
	}
}
