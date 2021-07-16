using Microsoft.Extensions.DependencyInjection;
using Trendyol.TyMiddleware.Core.MiddlewareCoreProcessService;
using Trendyol.TyMiddleware.Middlewares;
using Trendyol.TyMiddleware.Services.LogServices.LogBaseService;
using Trendyol.TyMiddleware.Services.LogServices.LogMiddlewareFilter;
using Trendyol.TyMiddleware.Services.LogServices.LogProvider;

namespace Trendyol.TyMiddleware.Registry
{
    public static class ServiceRegistry
    {
        public static void RegisterMiddlewareServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IMiddlewareService, MiddlewareService>();
            
            AddLogMiddlewareServices(serviceCollection);
        }

        private static void AddLogMiddlewareServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ILogProviderService, LogProviderService>();
            serviceCollection.AddScoped<ILogProfileService, LogProfileService>();
            serviceCollection.AddScoped<ILogService,LogService>();
            serviceCollection.AddScoped<LogMiddleware>();
            
        }
    }
}