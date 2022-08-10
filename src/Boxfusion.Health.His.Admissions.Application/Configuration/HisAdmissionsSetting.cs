using Abp.Configuration;
using Abp.Dependency;
using Shesha.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Boxfusion.Health.His.Admissions.Application.Configuration
{
    /// <summary>
    /// 
    /// </summary>
	public class HisAdmissionsSetting: IHisAdmissionsSettings, ITransientDependency
	{
        /// <summary>
        /// 
        /// </summary>
        protected ISettingManager _settingManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingManager"></param>
        public HisAdmissionsSetting(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public string HospitalIdentifier
        {
            get => _settingManager.GetSettingValue(HisAdmissionsSettingNames.HospitalIdentifier);
            set => _settingManager.ChangeSetting(HisAdmissionsSettingNames.HospitalIdentifier, value);
        }
    }
}
