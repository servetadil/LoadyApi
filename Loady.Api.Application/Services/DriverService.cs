using AutoMapper;
using Loady.Api.Application.Dto;
using Loady.Api.Core.Entities;
using Loady.Api.Core.Repository;

namespace Loady.Api.Application.Services
{
    public class DriverService : IDriverService
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<Driver> _driverRepository;
        public DriverService(IBaseRepository<Driver> driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DriverDto>> GetByCity(string cityName)
        {

            var drivers =  await _driverRepository.FilterBy(x => x.Location.City == cityName); 

            return _mapper.Map<IEnumerable<DriverDto>>(drivers);
        }
    }
}
