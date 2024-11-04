using ControllerLayer.Utils;
using DataAccessLayer;
using ModelLayer;
using System.Security.Claims;

namespace ControllerLayer.Middleware {
    public class UserActivityLoggingMiddleware {
        private readonly RequestDelegate _next;
        private readonly ApplicationDbContext _context;
        private readonly LocationService _locationService;

        public UserActivityLoggingMiddleware(RequestDelegate next) {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, ApplicationDbContext context, LocationService locationService) {
            try { 
                var userId = httpContext.User.Identity.IsAuthenticated ? httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier) : null;
                var ipAddress = httpContext.Connection.RemoteIpAddress?.ToString();
                var deviceType = httpContext.Request.Headers["User-Agent"].ToString();
                var location =  await locationService.GetLocationAsync(ipAddress);

                var userActivityLog = new UserActivityLog {
                    UserId = string.IsNullOrWhiteSpace(userId) ? "" :  userId,
                    Description =  String.Empty,
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
