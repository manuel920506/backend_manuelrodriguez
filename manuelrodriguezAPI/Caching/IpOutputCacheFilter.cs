using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace ControllerLayer.Caching {
    public class IpOutputCacheFilter : IAsyncActionFilter {
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _memoryCache;
        private readonly int _cacheDurationInMinutes;

        // Constructor injection for IConfiguration and IMemoryCache
        public IpOutputCacheFilter(IConfiguration configuration, IMemoryCache memoryCache) {
            _configuration = configuration;
            _memoryCache = memoryCache;

            // Retrieve the cache duration (could be configured in appsettings.json)
            _cacheDurationInMinutes = _configuration.GetValue<int>("IpOutputCacheDuration", 86400); // Default to 1 day
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next) {
            // Check if caching should be applied
            var clientIp  = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            if (clientIp  != null) {
                // Create a cache key based on IP address and route
                string cacheKey = $"{clientIp }_{context.HttpContext.Request.Path}";

                // Check if cached data exists
                if (_memoryCache.TryGetValue(cacheKey, out var cachedResult)) {
                    // If data is found in cache, return it as a result (bypassing the action execution)
                    context.Result = cachedResult as Microsoft.AspNetCore.Mvc.IActionResult;
                    return; // No need to proceed further, as we are returning cached result
                }
            }

            // Proceed with the action execution (it has not been cached)
            var resultContext = await next();

            // Cache the result after action execution
            if (resultContext.Result != null) {
                var clientIpAfterExecution  = context.HttpContext.Connection.RemoteIpAddress?.ToString();
                if (clientIpAfterExecution  != null) {
                    // Create a cache key based on IP and route
                    string cacheKey = $"{clientIpAfterExecution }_{context.HttpContext.Request.Path}";

                    // Set the cache entry with expiration time
                    _memoryCache.Set(cacheKey, resultContext.Result, TimeSpan.FromSeconds(_cacheDurationInMinutes));
                }
            }
        }
    }
}
