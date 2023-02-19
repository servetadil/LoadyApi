using Loady.Api.Application.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace Loady.Api.Middleware
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate _next;


        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(
            ILogger<ErrorHandlingMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var code = StatusCodes.Status500InternalServerError;
            var message = ex.Message;

            _logger.LogError(ex.ToString());

            switch (ex)
            {
                case CustomValidationException e:
                    code = StatusCodes.Status400BadRequest;
                    message = ex.Message;
                    break;
                case NotFoundException e:
                    code = StatusCodes.Status404NotFound;
                    message = ex.Message;
                    break;
                default:
                    // unhandled error
                    code = StatusCodes.Status500InternalServerError;
                    message = ex.Message;
                    break;
            }

            var result = JsonSerializer.Serialize(new { error = message });
            context.Response.Clear();
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = code;

            return context.Response.WriteAsync(result);
        }
    }
}