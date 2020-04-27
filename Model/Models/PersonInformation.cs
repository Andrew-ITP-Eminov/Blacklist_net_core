using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication
{
    public class PersonInformation
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public DateTime? TaskDate { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }
        public string Email { get; set; }
        public string Note { get; set; }
        public string INN { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public List<Client> Clients { get; set; }
        //public List<Driver> Drivers { get; set; }
    }
}