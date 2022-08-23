using Abp.Dependency;
using Boxfusion.Health.His.Admissions.Application.Hubs;
using Boxfusion.Health.His.Common.Admissions;
using EasyNetQ;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.His.Admissions.Application.Helpers
{
    public static class ServiceBusHelper
    {
        /// <summary>
        /// I am using this as an example for sending a massage to a topic named ExampleTopic
        /// </summary>
        /// <param name="admission"></param>
        /// <returns></returns>
        public static async Task TransferAddmission(WardAdmission admission)
        {
            await SendAsync("ExampleTopic", admission);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        private static async Task SendAsync(string key, object message)
        {
            await HandleMessage(key, message);
        }

        /// <summary>
        /// Handle different Messages
        /// </summary>
        private static async Task HandleMessage(string topic, object data)
        {
            var bus = IocManager.Instance.Resolve<IBus>();
            var hubContext = IocManager.Instance.Resolve<IHubContext<HisAdmisSignalRHub>>();
            var message = GetMessage(data);

            switch (topic)
            {
                case "ExampleTopic":
                    await hubContext.Clients.All.SendAsync(topic, message.ToString());
                    break;

                default:
                    await hubContext.Clients.All.SendAsync(topic, message.ToString());
                    break;
            }
        }

        private static object GetMessage(object data)
        {
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var message = JsonConvert.SerializeObject(data, camelCaseFormatter);
            return JsonConvert.DeserializeObject(message);
        }
    }
}
