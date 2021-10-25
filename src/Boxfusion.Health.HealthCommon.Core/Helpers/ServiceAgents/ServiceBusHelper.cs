using Abp.Dependency;
using EasyNetQ;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Shesha.RabbitMQ.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Boxfusion.Health.HealthCommon.Core.Helpers.ServiceAgents
{
    /// <summary>
    /// 
    /// </summary>
    public static class ServiceBusHelper
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static async Task SendAsync(string key, object message, Guid encounterId)
        {
            await HandleMessage(key, message, encounterId);
        }

        private static async Task HandleMessage(string topic, object data, Guid encounterId)
        {
            var bus = IocManager.Instance.Resolve<IBus>();
            var message = GetMessage(data);

            //switch (topic)
            //{
            //    case "LocationRetrieved":
            var exchange = await bus.Advanced.ExchangeDeclareAsync("pd_health", "topic");
            var queue1 = await bus.Advanced.QueueDeclareAsync("follow_up_pd_health");
            //var queue = await bus.Advanced.QueueDeclareAsync("service_request_pd_health");
            await bus.Advanced.BindAsync(exchange, queue1, "boxfusion.telehealth.followup.*");
            //await bus.Advanced.BindAsync(exchange, queue, "boxfusion.telehealth.servicequeue.*");
            await bus.PublishAsync("pd_health", message, $"boxfusion.telehealth.followup.{encounterId}.{topic}".ToLower());

            //await bus.PublishAsync("amq.topic", message, $"boxfusion.telehealth.servicequeue.{encounterId}.{topic}".ToLower());
            //await bus.PublishAsync("amq.topic", message, "boxfusion.telehealth.servicequeue.allocated");
            //        break;
            //    default:
            //        break;
            //}
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
