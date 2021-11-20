using Abp.Configuration;
using Abp.Dependency;
using Shesha.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Configuration
{
    /// <summary>
    /// 
    /// </summary>
	public class HisAdmissSetting: IHisAdmissSettings, ITransientDependency
	{
        /// <summary>
        /// 
        /// </summary>
        protected ISettingManager _settingManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingManager"></param>
        public HisAdmissSetting(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public string HospitalIdentifier
        {
            get => _settingManager.GetSettingValue(HisAdmissSettingNames.HospitalIdentifier);
            set => _settingManager.ChangeSetting(HisAdmissSettingNames.HospitalIdentifier, value);
        }
    }
}
