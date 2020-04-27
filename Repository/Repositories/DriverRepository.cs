using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication;

namespace WebApplication.Repository
{
    public class DriverRepository : IDriverRepository
    {
        ApplicationContext db;

        public DriverRepository(ApplicationContext _db)
        {
            db = _db;
        }
        public Task<Driver> AddDriver(Driver driver)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> GetDriver(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Driver>> GetDrivers()
        {
            /*
            if (db != null)
            {
                return (from driver in db.Driver
                        select new Driver
                        {
                             Id = driver.Id,
                             CompanyName = driver.FullName,
                             Phone = driver.Phone,
                        });

            }
            */
            return null;
        }

        public Task<Driver> RemoveDriver(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Driver> UpdateDriver(Driver driver)
        {
            throw new NotImplementedException();
        }
    }
}
