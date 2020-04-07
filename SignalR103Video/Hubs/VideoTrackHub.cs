using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR103Video.Hubs
{
    public class VideoTrackHub : Hub
    {
        public async Task SetVideoTime(decimal time)
        {
            //Clients.AllExcept(IReadOnlyList<string> excludedConnectionIds);
            await Clients.AllExcept(this.Context.ConnectionId).SendAsync("VideoTime", time);
        }

        public async Task Seeking(decimal time)
        {
            //Clients.AllExcept(IReadOnlyList<string> excludedConnectionIds);
            await Clients.AllExcept(this.Context.ConnectionId).SendAsync("Seeking", time);
        }

        public async Task Play()
        {
            //Clients.AllExcept(IReadOnlyList<string> excludedConnectionIds);
            await Clients.AllExcept(this.Context.ConnectionId).SendAsync("Play");
        }
        public async Task Pause()
        {
            //Clients.AllExcept(IReadOnlyList<string> excludedConnectionIds);
            await Clients.AllExcept(this.Context.ConnectionId).SendAsync("Pause");
        }
    }
}
