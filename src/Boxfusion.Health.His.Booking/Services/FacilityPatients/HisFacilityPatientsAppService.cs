using Abp.Authorization;
using Boxfusion.Health.His.Bookings.Services.FacilityPatients.Dtos;
using Boxfusion.Health.His.Bookings.Services.FacilityPatients.Helpers;
using Boxfusion.Health.His.Domain.Domain;
using Microsoft.AspNetCore.Mvc;
using Shesha.Web.DataTable;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Booking.Services.FacilityPatients
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/HisBookings/[controller]")]
    public class HisFacilityPatientsAppService : IHisFacilityPatientsAppService
    {
        private readonly IHisFacilityPatientsCrudHelper _hisPatientCrudHelper;
        /// <summary>
        /// 
        /// </summary>
        public HisFacilityPatientsAppService(IHisFacilityPatientsCrudHelper hisPatientCrudHelper)
        {
            _hisPatientCrudHelper = hisPatientCrudHelper;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static DataTableConfig FacilityPatientFlattened_Picker()
        {
            var table = new DataTableConfig<FacilityPatient, Guid>("FacilityPatientFlattened_Picker");
            table.AddProperty(e => e.FullName);
            table.AddProperty(e => e.IdentityNumber, u => u.Caption("ID/Passport No"));
            //table.AddProperty(e => e.)
            table.AddProperty(e => e.DateOfBirth, u => u.Caption("Date of Birth"));
            table.AddProperty(e => e.MobileNumber, u => u.Caption("Cellphone"));
            table.AddProperty(e => e.Gender);

            
            return table;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<FacilityPatientsResponse> CreateAsync(FacilityPatientsInput input)
        {
            return await _hisPatientCrudHelper.CreateAsync(input);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("")]
        public async Task<List<FacilityPatientsResponse>> GetAllAsync()
        {
            return await _hisPatientCrudHelper.GetAllAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="patientId"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public async Task<FacilityPatientsResponse> GetFacilityPatient(Guid id)
        {
            return await _hisPatientCrudHelper.GetAsync(id);
        }
    }
}
