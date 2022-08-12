using System.Threading.Tasks;
using Abp.Configuration;
using Microsoft.AspNetCore.Mvc;
using Shesha;

namespace Boxfusion.Health.HealthCommon.Core.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class CdmSettingsAppService: SheshaAppServiceBase
    {
        private readonly ICdmSettings _settingManager;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingManager"></param>
        public CdmSettingsAppService(ICdmSettings settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Update(CdmSettingsDto input)
        {
            if (input.CustomerKey != null)
                _settingManager.CustomerKey = input.CustomerKey;
            if (input.CustomerSecret != null)
                _settingManager.CustomerSecret = input.CustomerSecret;
            if (input.OrganisationIdentifier != null)
                _settingManager.OrganisationIdentifier = input.OrganisationIdentifier;
            if (input.FacilityIdentifier != null)
                _settingManager.FacilityIdentifier = input.FacilityIdentifier;
            if (input.AppCertificate != null)
                _settingManager.AppCertificate = input.AppCertificate;
            if (input.AppId != null)
                _settingManager.AppId = input.AppId;
            if (input.MedpraxUsername != null)
                _settingManager.MedpraxUsername = input.MedpraxUsername;
            if (input.MedpraxPassword != null)
                _settingManager.MedpraxPassword = input.MedpraxPassword;
            if (input.MedpraxBaseAddress != null)
                _settingManager.MedpraxBaseAddress = input.MedpraxBaseAddress;
        }        

        /// <summary>
        /// Returns Cdm settings
        /// </summary>
        public async Task<CdmSettingsDto> Get()
        {
            var result = new CdmSettingsDto()
            {
                CustomerKey = _settingManager.CustomerKey,
                CustomerSecret = _settingManager.CustomerSecret ,
                OrganisationIdentifier = _settingManager.OrganisationIdentifier,
                FacilityIdentifier = _settingManager.FacilityIdentifier,
                AppCertificate = _settingManager.AppCertificate,
                AppId = _settingManager.AppId,
                MedpraxUsername = _settingManager.MedpraxUsername,
                MedpraxPassword = _settingManager.MedpraxPassword,
                MedpraxBaseAddress = _settingManager.MedpraxBaseAddress,
            };

            return result;
        }
    }
}