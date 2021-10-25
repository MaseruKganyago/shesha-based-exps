using Boxfusion.Health.HealthCommon.Core.Services.HomeAffairs.Dto;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Services.HomeAffairs
{
    public abstract class HomeAffairsBaseService : CdmAppServiceBase
    {
        private readonly string _baseUri;
        private readonly IConfiguration _configuration;

        /// <summary>
        /// 
        /// </summary>
        public HomeAffairsBaseService()
        {
            _configuration = Abp.Dependency.IocManager.Instance.Resolve<IConfiguration>();
            _baseUri = _configuration.GetValue<string>("HomeAffairsApi:Address");
        }

        /// <summary>
        /// 
        /// </summary>
        protected async Task<HomeAffairsPersonDto> ValidateIdentityNumber(string iDNumber)
        {
            using (var client = new HttpClient())
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                client.BaseAddress = new Uri(_baseUri);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(iDNumber);

                var details = JsonConvert.DeserializeObject<HomeAffairsResponseDto>(
                    await response
                    .EnsureSuccessStatusCode()
                    .Content.ReadAsStringAsync()
                );

                return details.NprPerson;
            }
        }
    }
}
