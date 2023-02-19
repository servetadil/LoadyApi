using Loady.Api.Core.Entities;
using Loady.Api.Core.Repository;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Loady.Api.Application.Services
{
    public class DriverService : IDriverService
    {
        IBaseRepository<Driver> _driverRepository;
        public DriverService(IBaseRepository<Driver> driverRepository)
        {
            _driverRepository = driverRepository;
        }

        public async Task<IEnumerable<Driver>> GetByCity(string cityName)
        {
            return await _driverRepository.FilterBy(x => x.Location.City == cityName); 
        }
    }
}
