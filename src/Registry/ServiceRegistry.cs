using Microsoft.Extensions.DependencyInjection;
using Trendyol.TyMiddleware.Core.MiddlewareCoreProcessService;
using Trendyol.TyMiddleware.Middlewares;
using Trendyol.TyMiddleware.Services.LogServices.LogBaseService;
using Trendyol.TyMiddleware.Services.LogServices.LogMiddlewareFilter;
using Trendyol.TyMiddleware.Services.LogServices.LogProvider;
using Trendyol.TyMiddleware.Services.LogServices.LogStrategy.AbstractLogStrategy;
using Trendyol.TyMiddleware.Services.LogServices.LogStrategy.LogStrategyService;

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

            serviceCollection.AddScoped<ILogStrategy, LogStrategy>();
            serviceCollection.AddScoped<ILogStrategyService, LogConsoleService>();
            serviceCollection.AddScoped<ILogStrategyService, LogLoggerService>();

        }
    }
}