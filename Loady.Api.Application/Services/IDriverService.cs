using Loady.Api.Application.Dto;

namespace Loady.Api.Application.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDto>> GetByCity(string cityName);
    }
}