using Service.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Services
{
   public interface IClientService {

        Task<List<AllClientsDTO>> SearchByDTO(int currentPage, int PageSize, string Keyword);
        Task<List<AllClientsDTO>> GetClientsDTO(int currentPage, int PageSize);
        Task<ClientDTO> GetClientDTO(int? clientId);
        Task<int> AddClientDTO(ClientDTO client);
        Task<int> DeleteClientDTO(int? clientId);
        Task<int> UpdateClientDTO(ClientDTO client);
    }
}
