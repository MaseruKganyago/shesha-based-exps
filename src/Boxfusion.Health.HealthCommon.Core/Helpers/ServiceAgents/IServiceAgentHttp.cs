using Shesha.AutoMapper.Dto;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Helpers.ServiceAgents
{
    /// <summary>
    /// 
    /// </summary>
    public interface IServiceAgentHttp
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task<List<AutocompleteItemDto>> PostAsync(int pageIndex = 1, int pageSize = 100, string value = "");
    }
}
