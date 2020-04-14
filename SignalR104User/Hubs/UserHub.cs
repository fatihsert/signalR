using Microsoft.AspNetCore.SignalR;
using SignalR104User.Management;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR104User.Hubs
{
    public class UserHub : Hub
    {
        UserManager userManager;
        public UserHub(UserManager userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<User>> Join()
        {
            var user = new User()
            {
                ConnectionId = this.Context.ConnectionId,
                UserName = "Test_" + DateTime.Now.Ticks
            };

            this.userManager.Users.Add(user);


            await Clients.Others.SendAsync("JoinNewUser", user);

            return this.userManager.Users; ;
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            var user = this.userManager.Users.Where(q => q.ConnectionId == this.Context.ConnectionId).First();

            this.userManager.Users.Remove(user);

            Clients.Others.SendAsync("Disconnect", user);

            return base.OnDisconnectedAsync(exception);
        }
    }
}
