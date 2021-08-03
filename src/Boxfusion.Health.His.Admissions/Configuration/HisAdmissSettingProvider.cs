﻿using System.Collections.Generic;
using Abp.Configuration;
using Abp.Localization;

namespace Boxfusion.Health.His.Admissions.Configuration
{
    /// <summary>
    /// Defines Health.His settings
    /// </summary>
    public class HisAdmissSettingProvider : SettingProvider
    {
        protected string LocalizationSourceName { get; set; }

        public HisAdmissSettingProvider()
        {
            LocalizationSourceName = "HisAdmis";
        }

        public override IEnumerable<SettingDefinition> GetSettingDefinitions(SettingDefinitionProviderContext context)
        {
            return new SettingDefinition[]
            {
                //new SettingDefinition(Health.HisSettingNames.RevisitPeriod, (7*24*60).ToString() /* 7 days */, L("DSD_NPO_RevisitPeriod"), scopes: SettingScopes.Application | SettingScopes.Tenant, isInherited: false),
            };
        }

        protected virtual ILocalizableString L(string name)
        {
            return new LocalizableString(name, LocalizationSourceName);
        }
    }
}