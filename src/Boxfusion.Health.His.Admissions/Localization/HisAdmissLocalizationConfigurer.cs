using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Admissions.Application.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public static class HisAdmissLocalizationConfigurer
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
                        typeof(HisAdmissLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Admissions.Application.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
