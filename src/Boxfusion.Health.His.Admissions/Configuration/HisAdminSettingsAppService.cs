using System.Threading.Tasks;
using Abp.Configuration;
using Microsoft.AspNetCore.Mvc;
using Shesha;

namespace Boxfusion.Health.His.Admissions.Configuration
{
    public class HisAdmisSettingsAppService: SheshaAppServiceBase
    {
        private readonly ISettingManager _settingManager;
        
        public HisAdmisSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// Updates Health.His settings
        /// </summary>
        [HttpPost]
        public async Task Update(HisAdmisSettingsDto input)
        {
        }        

        /// <summary>
        /// Returns Health.His settings
        /// </summary>
        public async Task<HisAdmisSettingsDto> Get()
        {
            var result = new HisAdmisSettingsDto()
            {
            };

            return result;
        }

        /// <summary>
        /// Changes setting for tenant with fallback to application
        /// </summary>
        /// <param name="name">Setting name</param>
        /// <param name="value">Setting value</param>
        protected async Task ChangeSettingAsync(string name, string value)
        {
            // todo: move to IHealth.HisSettings
            if (AbpSession.TenantId.HasValue)
            {
                await _settingManager.ChangeSettingForTenantAsync(AbpSession.TenantId.Value, name, value);
            }
            else
            {
                await _settingManager.ChangeSettingForApplicationAsync(name, value);
            }
        }
    }
}