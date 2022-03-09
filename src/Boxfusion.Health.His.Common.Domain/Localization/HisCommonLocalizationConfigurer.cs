using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Common.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public static class HisCommonLocalizationConfigurer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localizationConfiguration"></param>
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HisCommon",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisCommonLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Common.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
