using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication
{
    public class Client
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int? AgreementNumber { get; set; }
        public string ContactPerson { get; set; }
        public int? PersonInformationId { get; set; }
        //public int? CreateUserId { get; set; }
        //public int? UpdateUserId { get; set; }
        //public User User { get; set; }
        public PersonInformation PersonInformation { get; set; }
    }
}