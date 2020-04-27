using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Services.Models
{
    public class AllClientsDTO
    {
        public int ClientId { get; set; }
        public string ClientCompanyName { get; set; }
        public int? ClientAgreementNumber { get; set; }
        public string ClientContactPerson { get; set; }
        public string ClientPhone { get; set; }
        public string ClientStatus { get; set; }      
    }
}
