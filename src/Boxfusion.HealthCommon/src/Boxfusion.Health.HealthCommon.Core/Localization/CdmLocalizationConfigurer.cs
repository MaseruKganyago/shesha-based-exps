using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.HealthCommon.Core.Localization
{
    public static class CdmLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("Cdm",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(CdmLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.HealthCommon.Core.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
