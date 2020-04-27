using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Repository
{
    public class ClientRepository : IClientRepository
    {
        ApplicationContext db;
        public ClientRepository(ApplicationContext _db)
        {
            db = _db;
        }
        public async Task<List<Client>> GetClients()
        {
            if (db != null)
            {
                return await (from p in db.Client.Include(c => c.PersonInformation)
                              select new Client
                              {
                                  Id = p.Id,
                                  CompanyName = p.CompanyName,
                                  AgreementNumber = p.AgreementNumber,
                                  ContactPerson = p.ContactPerson,
                                  PersonInformation = p.PersonInformation
                              }).ToListAsync();
            }
            
            return null;
        }
        public async Task<Client> GetClient(int? clientId)
        {
            if (db != null)
            {
                return await (from p in db.Client
                              where p.Id == clientId
                              select new Client
                              {
                                  Id = p.Id,
                                  CompanyName = p.CompanyName,
                                  AgreementNumber = p.AgreementNumber,
                                  ContactPerson = p.ContactPerson,
                              }).FirstOrDefaultAsync();
            }
            return null;
        }
        public async Task<int> AddClient(Client client)
        {
            if (db != null)
            {
                await db.Client.AddAsync(client);
                await db.SaveChangesAsync();
                return client.Id;
            }
            return 0;
        }
        public async Task<int> DeleteClient(int? clientId)
        {
            int result = 0;
            if (db != null)
            {
                var client = await db.Client.FirstOrDefaultAsync(x => x.Id == clientId);
                if (client != null)
                {
                    db.Client.Remove(client);
                    result = await db.SaveChangesAsync();
                }
                return result;
            }
            return result;
        }
        public async Task<int> UpdateClient(Client client)
        {
            if (db != null)
            { 
                db.Client.Update(client);
                await db.SaveChangesAsync();
                return client.Id;
            }
            return 0;
        }
    }
}
