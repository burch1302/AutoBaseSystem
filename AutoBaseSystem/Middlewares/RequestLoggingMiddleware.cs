using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AutoBaseSystem.Middlewares {
    public class RequestLoggingMiddleware {

        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context) {
            var method = context.Request.Method;
            var path = context.Request.Path;

            _logger.LogInformation("Incoming Request: {Method} {Path}", method, path);

            await _next(context);

            var statusCode = context.Response.StatusCode;

            _logger.LogInformation("Outgoing Response: {StatusCode}", statusCode); 
        }
    }
}
