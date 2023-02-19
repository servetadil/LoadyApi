using Loady.Api.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Loady.Api.Controllers
{
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;
        IDriverService _driverService;
        public DriverController(
            ILogger<DriverController> logger,
            IDriverService driverService)
        {
            _logger = logger;
            _driverService = driverService;
        }

        [HttpGet]
        [Route("Driver/GetBy")]
        public async Task<IActionResult> GetBy(string cityName)
        {
            var drivers = await _driverService.GetByCity(cityName);
            return Ok(drivers);
        }
    }
}