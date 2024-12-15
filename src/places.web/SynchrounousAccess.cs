using Microsoft.Extensions.Caching.Distributed;

namespace places.web
{
    public class SynchrounousAccess
    {
        private readonly RequestDelegate _next;

        public SynchrounousAccess(RequestDelegate next) => _next = next;

        public async Task InvokeAsync(HttpContext httpContext, IDistributedCache cache)
        {
            var key = httpContext.Connection.RemoteIpAddress!.ToString();

            if (await cache.GetAsync(key) != null)
            {
                while (cache.GetAsync(key) != null)
                {
                    await Task.Yield();

                    Thread.Sleep(10);
                }
            }
            else
            {
                await cache.SetAsync(key, [0x00]);
                await _next(httpContext);
                await cache.RemoveAsync(key);
            }
        }
    }

    public static class SynchrounousAccessExtensions
    {
        public static IApplicationBuilder UseSynchronousAccess(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SynchrounousAccess>();
        }
    }
}
