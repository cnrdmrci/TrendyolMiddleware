using Microsoft.Extensions.DependencyInjection;
using TrendyolMiddleware.MiddlewareManagement.Configuration;
using TrendyolMiddleware.MiddlewareManagement.Configuration.Concrete;
using TrendyolMiddleware.Services.Middleware;
using TrendyolMiddleware.Services.RestServices.HttpContexts;

namespace TrendyolMiddleware.Registry
{
    public static class ServiceRegistry
    {
        public static void RegisterMiddlewareServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMiddlewareService, MiddlewareService>();
            serviceCollection.AddScoped<IHttpContextService, HttpContextService>();
            serviceCollection.AddSingleton<IConfigurationManagementService, ConfigurationManagementService>();
        }
    }
}