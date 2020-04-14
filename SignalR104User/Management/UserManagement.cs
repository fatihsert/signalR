using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalR104User.Management
{
    public class UserManager
    {
        public List<User> Users { get; set; }
        public UserManager()
        {
            Users = new List<User>();
        }

    }

    public class User
    {
        public string ConnectionId { get; set; }
        public string UserName { get; set; }
    }

}
