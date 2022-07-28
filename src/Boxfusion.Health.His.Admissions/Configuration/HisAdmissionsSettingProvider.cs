﻿using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace Boxfusion.Health.His.Admissions.Application.Configuration
{
    /// <summary>
    /// Defines Health.His settings
    /// </summary>
    public class HisAdmissionsSettingProvider : SettingProvider
    {
        /// <summary>
        /// 
        /// </summary>
        protected string LocalizationSourceName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public HisAdmissionsSettingProvider()
        {
            LocalizationSourceName = "HisAdmiss";
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new SettingDefinition[]
            {
                new SettingDefinition(HisAdmissionsSettingNames.HospitalIdentifier, false.ToString(), L("HospitalIdentifier"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        protected virtual ILocalizableString L(string name)
        {
            return new LocalizableString(name, LocalizationSourceName);
        }
    }
}