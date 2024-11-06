using ControllerLayer.Utils;
using DataAccessLayer;
using ModelLayer;
using System.Security.Claims;

namespace ControllerLayer.Middleware {
    public class UserActivityLoggingMiddleware {
        private readonly RequestDelegate _next; 

        public UserActivityLoggingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ApplicationDbContext context, LocationService locationService) {
            try { 
                var userId = httpContext.User.Identity.IsAuthenticated ? httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
                var ipAddress = httpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault(); 
                if (string.IsNullOrEmpty(ipAddress)) {
                    ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
                }
                var requestMethod = httpContext.Request.Method;          
                var requestPath = httpContext.Request.Path;             
                var queryString = httpContext.Request.QueryString;
                var deviceType = httpContext.Request.Headers["User-Agent"].ToString();
                var location =  await locationService.GetLocationAsync(ipAddress);
                var description = string.Format("Request received - Method: {0}, Path: {1}, Query: {2}",
                                   requestMethod,
                                   requestPath,
                                   queryString.HasValue ? queryString.Value : "None");

                var userActivityLog = new UserActivityLog {
                    UserId = string.IsNullOrWhiteSpace(userId) ? "" :  userId,
                    Description = string.IsNullOrWhiteSpace(description) ? "" : description,
                    IpAddress = string.IsNullOrWhiteSpace(ipAddress) ? "" : ipAddress,
                    DeviceType = string.IsNullOrWhiteSpace(deviceType) ? "" : deviceType,
                    Location = string.IsNullOrWhiteSpace(location) ? "" : location,
                    Timestamp = DateTime.UtcNow
                };

                context.UserActivityLogs.Add(userActivityLog);
                await context.SaveChangesAsync();

                await _next(httpContext);
            } catch (Exception ex) {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }  
    }
}
