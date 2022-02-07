﻿using Abp.Authorization;
using Boxfusion.Health.His.Bookings.Services.FacilityPatients.Dtos;
using Boxfusion.Health.His.Bookings.Services.FacilityPatients.Helpers;
using Microsoft.AspNetCore.Mvc;
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