using Microsoft.Extensions.DependencyInjection;
using TrendyolMiddleware.Services.Middleware;
using TrendyolMiddleware.Services.Middleware.CoreMiddleware;
using TrendyolMiddleware.Services.RestServices.HttpContexts;

namespace TrendyolMiddleware.Registry
{
    public static class ServiceRegistry
    {
        public static void RegisterMiddlewareServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMiddlewareService, MiddlewareService>();
            serviceCollection.AddScoped<IHttpContextService, HttpContextService>();
        }
    }
}