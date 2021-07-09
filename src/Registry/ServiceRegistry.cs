using Microsoft.Extensions.DependencyInjection;
using TrendyolMiddleware.Services.Middleware;

namespace TrendyolMiddleware.Registry
{
    public static class ServiceRegistry
    {
        public static void RegisterMiddlewareServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMiddlewareService, MiddlewareService>();
        }
    }
}