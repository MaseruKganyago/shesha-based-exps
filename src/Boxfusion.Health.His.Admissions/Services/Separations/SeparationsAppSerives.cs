using Abp.Authorization;
using Boxfusion.Health.HealthCommon.Core.Helpers.Validations;
using Boxfusion.Health.HealthCommon.Core.Services;
using Boxfusion.Health.His.Admissions.Services.Separations.Dto;
using Boxfusion.Health.His.Admissions.Services.Separations.Helpers;
using Boxfusion.Health.His.Domain.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Services.Separations
{
    /// <summary>
    /// 
    /// </summary>
    [AbpAuthorize]
    [ApiVersion("1")]
    [Route("api/v{version:apiVersion}/His/[controller]")]
    public class SeparationsAppSerives : CdmAppServiceBase, ISeparationsAppService
    {
        private readonly ISeparationCrudHelper _separationCrudHelper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="separationCrudHelper"></param>
        public SeparationsAppSerives(ISeparationCrudHelper separationCrudHelper)
        {
            _separationCrudHelper = separationCrudHelper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost, Route("")]
        public async Task<SeparationResponse> CreateAsync(SeparationInput input)
        {
            var person = await GetCurrentLoggedPersonFhirBaseAsync();

            Validation.ValidateReflist(input?.SeparationType, "Separation Type");
            Validation.ValidateReflist(input?.SeparationChildHealth, "Separation Child Health");
            Validation.ValidateNullableType(input?.SeparationDate, "Separation Date");
            Validation.ValidateNullableType(input?.Code, "Icd-10 Code");

            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.internalTransfer)
            {
                Validation.ValidateNullableType(input?.SeparationDestinationWard, "Separation Destination Ward");
            }

            if (input?.SeparationType?.ItemValue == (int?)RefListSeparationTypes.externalTransfer)
            {
                if (input.IsGautengGovFacility)
                    Validation.ValidateNullableType(input?.TransferToHospital, "Gauteng Government Destination Hospital");
                else
                    Validation.ValidateText(input?.TransferToNonGautengHospital, "None Gauteng Government Destination Hospital");
            }

            var separation = await _separationCrudHelper.CreateAsync(input, person);
            return separation;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete, Route("{id}")]
        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("{id}")]
        public Task<SeparationResponse> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPut, Route("")]
        public Task<SeparationResponse> UpdateAsync(SeparationInput input)
        {
            throw new NotImplementedException();
        }
    }
}
