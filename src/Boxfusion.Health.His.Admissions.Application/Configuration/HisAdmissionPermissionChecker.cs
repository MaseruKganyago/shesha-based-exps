using Shesha.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Application.Configuration
{
    public class HisAdmissionPermissionChecker : IHisAdmissionPermissionChecker
    {
        public HisAdmissionPermissionChecker()
        {

        }

        public async Task<bool> IsApproverLevel1(Person person)
        {
            //Todo: Impliment 
            return true;
        }
    }
}
