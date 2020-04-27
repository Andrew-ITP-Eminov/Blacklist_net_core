using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication
{
    public class Driver
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Region { get; set; }
        public string TsType { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }
        public int PersonInformationId { get; set; }
        public User User { get; set; }
        public PersonInformation PersonInformation { get; set; }
    }
}
