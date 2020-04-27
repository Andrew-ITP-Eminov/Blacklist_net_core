using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        //public List<Client> Clients { get; set; }
        public List<Driver> Drivers { get; set; }
        public List<RoleUser> RoleUsers { get; set; }
        public User()
        {
            RoleUsers = new List<RoleUser>();
        }

    }
}

