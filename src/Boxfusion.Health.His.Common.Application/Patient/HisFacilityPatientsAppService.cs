using Abp.Authorization;
using Boxfusion.Health.His.Domain;
using Microsoft.AspNetCore.Mvc;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Common.Patients
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/HisBookings/[controller]")]
    [Obsolete("Should remove once configuration driven entity pickers are implemented")]
    public class HisFacilityPatientAppService : HisAppServiceBase
    {

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig FacilityPatientFlattened_OLD_Picker()
        {
            var table = new DataTableConfig<FacilityPatient, Guid>("FacilityPatientFlattened_OLD_Picker");
            table.AddProperty(e => e.FullName);
            table.AddProperty(e => e.IdentityNumber, u => u.Caption("ID/Passport No"));
            //table.AddProperty(e => e.)
            table.AddProperty(e => e.DateOfBirth, u => u.Caption("Date of Birth"));
            table.AddProperty(e => e.MobileNumber1, u => u.Caption("Cellphone"));
            table.AddProperty(e => e.Gender);
            
            return table;
        }

        public static DataTableConfig FlattenedFacilityPatient_Picker()
        {
            var table = new DataTableConfig<FlattenedFacilityPatient, Guid>("Patients_Index");
            table.AddProperty(e => e.FullName);
            table.AddProperty(e => e.FacilityPatientIdentifier);
            table.AddProperty(e => e.IdentityNumber, u => u.Caption("ID/Passport No"));
            //table.AddProperty(e => e.)
            table.AddProperty(e => e.DateOfBirth, u => u.Caption("Date of Birth"));
            table.AddProperty(e => e.MobileNumber1, u => u.Caption("Cellphone"));
            table.AddProperty(e => e.Gender);
            table.OnRequestToFilterStatic = (criteria, input) =>
            {
                Guid facilityId = RequestContextHelper.FacilityId;
                criteria.FilterClauses.Add($"ent.FacilityId = '{facilityId}'");
            };

            return table;
        }
    }
}
