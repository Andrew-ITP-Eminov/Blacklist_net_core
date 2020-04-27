using Service.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Services
{
   public interface IClientService {
        Task<List<AllClientsDTO>> GetClientsDTO();
        Task<ClientDTO> GetClientDTO(int? clientId);
        Task<int> AddClientDTO(ClientDTO client);
        Task<int> DeleteClientDTO(int? clientId);
        Task<int> UpdateClientDTO(ClientDTO client);
    }
}
