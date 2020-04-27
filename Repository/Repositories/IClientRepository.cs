using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Repository
{
    public interface IClientRepository
    {
        Task<List<Client>> GetClients();
        Task<Client> GetClient(int? clientId);
        Task<int> AddClient(Client client);
        Task<int> DeleteClient(int? clientId);
        Task<int> UpdateClient(Client client);
    }   
}
