using Loady.Api.Core.Entities;

namespace Loady.Api.Application.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<Driver>> GetByCity(string cityName);
    }
}