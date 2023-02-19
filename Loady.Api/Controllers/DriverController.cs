using FluentValidation;
using Loady.Api.Application.Exceptions;
using Loady.Api.Application.Model;
using Loady.Api.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Loady.Api.Controllers
{
    [ApiController]
    public class DriverController : ControllerBase
    {
        private IValidator<GetByCityQueryModel> _validator;
        IDriverService _driverService;

        public DriverController(
            IValidator<GetByCityQueryModel> validator,
            IDriverService driverService)
        {
            _validator = validator;
            _driverService = driverService;
        }

        [HttpGet]
        [Route("Driver/GetByCity")]
        [Produces("application/json")]
        public async Task<IActionResult> GetByCity([FromQuery] GetByCityQueryModel model)
        {
           var validator =  await _validator.ValidateAsync(model);

            if (!validator.IsValid)
            {
               throw new CustomValidationException(validator.Errors);
            }

            return Ok(await _driverService.GetByCity(model.City));
        }
    }
}