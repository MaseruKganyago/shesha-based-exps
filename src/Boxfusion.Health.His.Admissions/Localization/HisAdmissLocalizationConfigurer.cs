using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Admissions.Localization
{
    public static class HisAdmissLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HisAdmiss",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisAdmissLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Admissions.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
