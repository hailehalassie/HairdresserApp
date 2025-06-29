using System.Net;
using System.Text.Json;

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
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

                var response = new
                {
                    StatusCode = context.Response.StatusCode,
                    Message = "An internal server error occurred.",
                    Detail = ex.Message // Optional: hide in production
                };

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