using System.Threading.Tasks;
using Abp.Configuration;
using Microsoft.AspNetCore.Mvc;
using Shesha;

namespace Boxfusion.Health.His.Admissions.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class HisAdmissionsSettingsAppService: SheshaAppServiceBase
    {
        private readonly ISettingManager _settingManager;
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingManager"></param>
        public HisAdmissionsSettingsAppService(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task Update(HisAdmissionsSettingsDto input)
        {
        }        

        /// <summary>
        /// Returns Health.His settings
        /// </summary>
        public async Task<HisAdmissionsSettingsDto> Get()
        {
            var result = new HisAdmissionsSettingsDto()
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