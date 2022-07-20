using Abp.Dependency;
using Abp.Runtime.Session;
using Castle.Core.Logging;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Boxfusion.Health.His.Admissions.Application.Hubs
{
    /// <summary>
    /// 
    /// </summary>
    public class HisAdmisSignalRHub : Hub, ITransientDependency
    {
        /// <summary>
        /// 
        /// </summary>
        public IAbpSession AbpSession { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public ILogger Logger { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public HisAdmisSignalRHub()
        {
            AbpSession = NullAbpSession.Instance;
            Logger = NullLogger.Instance;
        }
        /// <summary>
        /// Used for sending SignalR Messages
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("getMessage", string.Format("User {0}: {1}", AbpSession.UserId, message));
        }
        /// <summary>
        /// Used for handling connecting
        /// </summary>
        /// <returns></returns>
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            Logger.Debug("A client connected to MyChatHub: " + Context.ConnectionId);
        }
        /// <summary>
        /// Used for handling Disconnecting
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            Logger.Debug("A client disconnected from MyChatHub: " + Context.ConnectionId);
        }
    }
}
