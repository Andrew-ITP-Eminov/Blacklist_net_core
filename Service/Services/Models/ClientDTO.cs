
namespace Service.Services.Models
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string ClientCompanyName { get; set; }
        public int? ClientAgreementNumber { get; set; }
        public string ClientContactPerson { get; set; }
        public string ClientPhone { get; set; }
        public string ClientStatus { get; set; }
        public string ClientEmail { get; set; }
        public string ClientNote { get; set; }
        public string ClientINN { get; set; }
    }
}