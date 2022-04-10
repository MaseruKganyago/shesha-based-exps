using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Admissions.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public static class HisAdmissionsLocalizationConfigurer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localizationConfiguration"></param>
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HisAdmissions",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisAdmissionsLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Admissions.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
