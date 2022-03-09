using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace Boxfusion.Health.His.Bookings.Localization
{
    /// <summary>
    /// 
    /// </summary>
    public static class HisBookingsLocalizationConfigurer
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="localizationConfiguration"></param>
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource("HisBookings",
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(HisBookingsLocalizationConfigurer).GetAssembly(),
                        "Boxfusion.Health.His.Booking.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
