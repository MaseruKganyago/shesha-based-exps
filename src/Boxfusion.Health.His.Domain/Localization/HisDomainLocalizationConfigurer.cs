using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Domain.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public static class HisDomainLocalizationConfigurer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localizationConfiguration"></param>
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HisDomain",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisDomainLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Domain.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
