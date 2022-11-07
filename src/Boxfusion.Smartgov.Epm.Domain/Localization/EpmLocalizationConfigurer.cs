using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Smartgov.Epm.Localization
{
	public static class EpmLocalizationConfigurer
	{
		/// <summary>
		/// 
		/// </summary>
		/// <param name="localizationConfiguration"></param>
		public static void Configure(ILocalizationConfiguration localizationConfiguration)
		{
			localizationConfiguration.Sources.Add(
				new DictionaryBasedLocalizationSource("Epm",
					new XmlEmbeddedFileLocalizationDictionaryProvider(
						typeof(EpmLocalizationConfigurer).GetAssembly(),
						"Boxfusion.Smartgov.Epm.Localization.SourceFiles"
					)
				)
			);
		}
	}
}
