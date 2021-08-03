using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Localization
{
    public static class HisLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("His",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
