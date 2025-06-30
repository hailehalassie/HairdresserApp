using System.Net;
using System.Text.Json;
using Application.Exceptions;
using API.Models;

namespace API.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Call the next middleware
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An unhandled exception occurred.");

                context.Response.ContentType = "application/json";
                // context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

               var response = new ErrorResponse();
                int statusCode;

                switch (ex)
                {
                    case ValidationException validationEx:
                        statusCode = validationEx.StatusCode;
                        response.Message = validationEx.Message;
                        response.Errors = validationEx.Errors
                                            .SelectMany(kvp => kvp.Value)
                                            .ToList();
                        break;
                    
                    case NotFoundException notFoundEx:
                        statusCode = notFoundEx.StatusCode;
                        response.Message = notFoundEx.Message;
                        break;

                    case AppException appEx:
                        statusCode = appEx.StatusCode;
                        response.Message = appEx.Message;
                        break;

                    default:
                        statusCode = (int)HttpStatusCode.InternalServerError;
                        response.Message = "An unexpected error occurred.";
                        break;
                }

                context.Response.StatusCode = statusCode;
                var json = JsonSerializer.Serialize(response);
                await context.Response.WriteAsync(json);
            }
        }


    }
      // Extension method for easy registration
        public static class ExceptionHandlingMiddlewareExtensions
        {
            public static IApplicationBuilder UseExceptionHandling(this IApplicationBuilder app)
            {
                return app.UseMiddleware<ExceptionHandlingMiddleware>();
            }
        }
}