using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR101.Hubs
{
    public class ChatHub : Hub
    {
        public string test;

        public async Task SendMessage(string user, string message)
        {
            test = "asdf";

            await Clients.All.SendAsync("Hello", user, message);
        }
        public override Task OnConnectedAsync()
        {
            Task connected = base.OnConnectedAsync();


            return connected;
        }
        
        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}
