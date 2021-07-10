using Microsoft.Extensions.DependencyInjection;
using Trendyol.TyMiddleware.Services.Middleware;

namespace Trendyol.TyMiddleware.Registry
{
    public static class ServiceRegistry
    {
        public static void RegisterMiddlewareServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMiddlewareService, MiddlewareService>();
        }
    }
}