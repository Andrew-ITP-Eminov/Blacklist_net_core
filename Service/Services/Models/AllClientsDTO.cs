namespace Service.Services.Models
{
    public class AllClientsDTO
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public int? AgreementNumber { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }      
    }
}
