using Abp.Configuration;
using Abp.Dependency;
using Shesha.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public class CdmSettings : ICdmSettings, ITransientDependency
    {
        /// <summary>
        /// 
        /// </summary>
        protected ISettingManager _settingManager { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingManager"></param>
        public CdmSettings(ISettingManager settingManager)
        {
            _settingManager = settingManager;
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerSecret
        { 
            get => _settingManager.GetSettingValue(CdmSettingNames.CustomerSecret); 
            set => _settingManager.ChangeSetting(CdmSettingNames.CustomerSecret, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerKey 
        {
            get => _settingManager.GetSettingValue(CdmSettingNames.CustomerKey);
            set => _settingManager.ChangeSetting(CdmSettingNames.CustomerKey, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string OrganisationIdentifier 
        {
            get => _settingManager.GetSettingValue(CdmSettingNames.OrganisationIdentifier);
            set => _settingManager.ChangeSetting(CdmSettingNames.OrganisationIdentifier, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string FacilityIdentifier
        {
            get => _settingManager.GetSettingValue(CdmSettingNames.FacilityIdentifier);
            set => _settingManager.ChangeSetting(CdmSettingNames.FacilityIdentifier, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string AppCertificate 
        { 
            get => _settingManager.GetSettingValue(CdmSettingNames.AppCertificate);
            set => _settingManager.ChangeSetting(CdmSettingNames.AppCertificate, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string AppId 
        { 
            get => _settingManager.GetSettingValue(CdmSettingNames.AppId); 
            set => _settingManager.ChangeSetting(CdmSettingNames.AppId, value); 
        }

        /// <summary>
        /// 
        /// </summary>
        public string MedpraxUsername
        {
            get => _settingManager.GetSettingValue(CdmSettingNames.MedpraxUsername);
            set => _settingManager.ChangeSetting(CdmSettingNames.MedpraxUsername, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string MedpraxPassword
        {
            get => _settingManager.GetSettingValue(CdmSettingNames.MedpraxPassword);
            set => _settingManager.ChangeSetting(CdmSettingNames.MedpraxPassword, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public string MedpraxBaseAddress
        {
            get => _settingManager.GetSettingValue(CdmSettingNames.MedpraxBaseAddress);
            set => _settingManager.ChangeSetting(CdmSettingNames.MedpraxBaseAddress, value);
        }
    }
}
