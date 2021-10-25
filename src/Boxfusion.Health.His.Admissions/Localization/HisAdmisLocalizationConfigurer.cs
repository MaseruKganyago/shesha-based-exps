using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Admissions.Localization
{
    public static class HisAdmisLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HisAdmis",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisAdmisLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Admissions.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
