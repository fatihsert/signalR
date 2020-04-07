using Microsoft.AspNetCore.SignalR;
using SignalR102.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR102.Manager
{
    public class UserHubManager
    {
        public List<string> Users { get; set; }
        public UserHubManager(IHubContext<ContentHub> hub)
        {
            Users = new List<string>();
        }

        public class MyClass
        {

        }
    }
}
