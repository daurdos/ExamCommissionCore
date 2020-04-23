using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class UserWithRoles
    {
        public string UserName { get; set; }
        public string[] Roles { get; set; }


        public UserWithRoles(string userName, string[] roles)
        {
            UserName = userName;
            Roles = roles;
        }
    }
}
