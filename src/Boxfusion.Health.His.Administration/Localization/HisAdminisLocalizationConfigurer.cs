using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Administration.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public static class HisAdminisLocalizationConfigurer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localizationConfiguration"></param>
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HisAdminis",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisAdminisLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Administration.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
