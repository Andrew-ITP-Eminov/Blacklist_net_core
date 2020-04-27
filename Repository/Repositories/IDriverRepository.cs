using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApplication;

namespace Repository.Repositories
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetDrivers();
        Task<Driver> GetDriver(int? id);
        Task<Driver> RemoveDriver(int? id);
        Task<Driver> UpdateDriver(Driver driver);
        Task<Driver> AddDriver(Driver driver);

    }
}
