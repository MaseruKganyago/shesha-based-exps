using Abp.AutoMapper;
using Shesha.Authentication.External;

namespace Boxfusion.Smartgov.Epm.TokenAuth
{
    [AutoMapFrom(typeof(ExternalLoginProviderInfo))]
    public class ExternalLoginProviderInfoModel
    {
        public string Name { get; set; }

        public string ClientId { get; set; }
    }
}
