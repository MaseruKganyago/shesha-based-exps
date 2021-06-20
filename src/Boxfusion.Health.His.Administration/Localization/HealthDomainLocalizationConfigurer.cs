using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.Domain.Localization
{
    public static class HealthDomainLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HealthDomain",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HealthDomainLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.Domain.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
