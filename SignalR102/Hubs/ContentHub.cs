using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using SignalR102.Manager;
using SignalR102.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR102.Hubs
{
    public class ContentHub : Hub
    {
        ContentHubManager contentHubManager;
        public ContentHub(ContentHubManager contentHubManager)
        {
            this.contentHubManager = contentHubManager;
        }

        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            
            return base.OnDisconnectedAsync(exception);
        }

        public async Task SendScroll(int x, int y)
        {
            contentHubManager.Scroll.X = x;
            contentHubManager.Scroll.Y = y;
            this.Context.Items.Add("fat", "asdf");
            
            
            await Clients.All.SendAsync("Scroll", x, y);
        }

        public async Task<string> GetContent()
        {
            return contentHubManager.Content;
        }

        public async Task<string> GetCurrentScroll()
        {
            return JsonConvert.SerializeObject(contentHubManager.Scroll);
        }

    }
}
