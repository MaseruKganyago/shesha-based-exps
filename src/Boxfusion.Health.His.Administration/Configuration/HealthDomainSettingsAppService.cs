using System.Threading.Tasks;
using Abp.Configuration;
using Microsoft.AspNetCore.Mvc;
using Shesha;

namespace Boxfusion.Health.Domain.Configuration
{
    public class HealthDomainSettingsAppService: SheshaAppServiceBase
    {
        private readonly ISettingManager _settingManager;
        
        public HealthDomainSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// Updates HealthDomain settings
        /// </summary>
        [HttpPost]
        public async Task Update(HealthDomainSettingsDto input)
        {
        }        

        /// <summary>
        /// Returns HealthDomain settings
        /// </summary>
        public async Task<HealthDomainSettingsDto> Get()
        {
            var result = new HealthDomainSettingsDto()
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
            // todo: move to IHealthDomainSettings
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