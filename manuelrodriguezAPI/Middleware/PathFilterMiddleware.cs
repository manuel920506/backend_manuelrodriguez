using ControllerLayer.Utils;
using DataAccessLayer;
using ModelLayer;
using System.Security.Claims;

namespace ControllerLayer.Middleware {
    public class PathFilterMiddleware {
        private readonly RequestDelegate _next;
        private readonly HashSet<string> _allowedPaths;

        public PathFilterMiddleware(RequestDelegate next, IConfiguration configuration) {
            _next = next;
            _allowedPaths = configuration.GetSection("AllowedPaths").Get<HashSet<string>>() ?? new HashSet<string>();
        }


        public async Task InvokeAsync(HttpContext context) {
            var requestPath = context.Request.Path.Value;

            // Check if the request path is allowed
            if (_allowedPaths.Contains(requestPath)) {
                await _next(context); // Proceed to the next middleware if allowed
            } else {
                // Block the request and return a 403 Forbidden status code
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync("Access Denied: This path is not allowed.");
            }
        }
    }
}
