using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Phd.Models
{
    public class UserWithRoles
    {
        public string UserName { get; set; }
        
        public string Lname { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string[] Roles { get; set; }


        public UserWithRoles(string userName, string[] roles)
        {
            UserName = userName;
            Roles = roles;
        }

        public UserWithRoles(string Lname, string Fname, string Mname, string[] roles)
        {
            Lname = Lname;
            Fname = Fname;
            Mname = Mname;
            Roles = roles;
        }
    }
}
