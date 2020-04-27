using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication
{
    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public List<RoleUser> RoleUsers { get; set; }
        public Role()
        {
            RoleUsers = new List<RoleUser>();
        }
    }
}
