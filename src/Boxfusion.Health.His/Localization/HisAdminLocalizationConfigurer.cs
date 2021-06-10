using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Admissions.Localization
{
    public static class HisAdminLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HisAdmin",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisAdminLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Admissions.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
