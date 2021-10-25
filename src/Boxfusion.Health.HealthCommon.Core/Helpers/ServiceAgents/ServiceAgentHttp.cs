using Abp.Dependency;
using Abp.UI;
using AutoMapper;
using Boxfusion.Health.HealthCommon.Core.Configuration;
using Boxfusion.Health.HealthCommon.Core.Services.MedicationRequests.Dtos;
using Newtonsoft.Json;
using RestSharp;
using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Helpers.ServiceAgents
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class ServiceAgentHttp :IServiceAgentHttp, ITransientDependency
    {
        private readonly ICdmSettings _cdmSettings;
        private readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cdmSettings"></param>
        /// <param name="mapper"></param>
        public ServiceAgentHttp(
            ICdmSettings cdmSettings,
            IMapper mapper)
        {
            _cdmSettings = cdmSettings;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public async Task<List<AutocompleteItemDto>> PostAsync(int pageIndex = 1, int pageSize = 100, string value = "")
        {
            var client = new RestClient(_cdmSettings.MedpraxBaseAddress + $"products/medicine/list?filterjoin=And&asc=true&orderPropertyName=Name&pageIndex={pageIndex}&pageSize={pageSize}");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            var sessionToken = await loginAsync();

            request.AddHeader("Authorization", $"SessionToken {sessionToken}");
            request.AddHeader("Content-Type", "application/json");

            var productRequests = new List<ProductRequest>() { new ProductRequest(value) { } };

            var body = JsonConvert.SerializeObject(productRequests);

            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new UserFriendlyException(response.ErrorMessage);

            var productResponse = JsonConvert.DeserializeObject<Root>(response.Content);


            return _mapper.Map<List<AutocompleteItemDto>>(productResponse.Products.PageResult);
        }

        private async Task<string> loginAsync()
        {
            var client = new RestClient(_cdmSettings.MedpraxBaseAddress + "authenticate");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");

            var body = new LoginRequest { UserName = _cdmSettings.MedpraxUsername, Password = _cdmSettings.MedpraxPassword };

            request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new UserFriendlyException(response.ErrorMessage);

            var loginResponse = JsonConvert.DeserializeObject<LoginResponse>(response.Content);

            return loginResponse.SessionToken;
        }
    }
}
