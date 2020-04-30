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
        public async Task<List<Client>> GetClients(int currentPage, int PageSize)
        {
            if (db != null)
            {
                return await db.Client.Include(c => c.PersonInformation)
                    .OrderBy(c => c.CompanyName)
                    .Skip((currentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
            }
            
            return null;
        }
        public async Task<Client> GetClient(int? clientId)
        {
            if (db != null)
            {
                return await db.Client.Include(c => c.PersonInformation).FirstOrDefaultAsync(c => c.Id == clientId);
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

        public async Task<List<Client>> GetSearchBy(int currentPage, int PageSize, string Keyword)
        {
            if (db != null)
            {
                //return await db.Client.FromSqlRaw("SELECT * FROM Client query").ToListAsync();

                return await db.Client
                    .FromSqlRaw("SELECT t1.*, t2.Phone, t2.Status FROM Client t1 " +
                                    "JOIN PersonInformation t2 ON t2.Id = t1.PersonInformationId " +
                                    "WHERE t1.CompanyName LIKE {0} OR t2.Phone LIKE {0} ", "%"+Keyword+"%")
                    .Include(c => c.PersonInformation)
                    .Skip((currentPage - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
            }

            return null;
        }
    }
}
