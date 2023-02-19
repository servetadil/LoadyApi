using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Loady.Api.Controllers
{
    [ApiController]
    public class DriverController : ControllerBase
    {
        private readonly ILogger<DriverController> _logger;

        public DriverController(ILogger<DriverController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("Driver/GetBy")]
        public async Task<IActionResult> GetBy()
        {
            return Ok("");
        }
    }
}