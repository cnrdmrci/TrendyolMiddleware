using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Trendyol.TyMiddleware.Configuration;
using Trendyol.TyMiddleware.Core.MiddlewareMainGate;
using Trendyol.TyMiddleware.Registry;

namespace Trendyol.TyMiddleware
{
    public static class DependencyExtension
    {
        public static void AddTyMiddleware(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterMiddlewareServices();
        }
        
        public static void AddTyMiddleware(this IServiceCollection serviceCollection,Action<MiddlewareConfiguration> middlewareConfigurationAction)
        {
            serviceCollection.RegisterMiddlewareServices();
            middlewareConfigurationAction(new MiddlewareConfiguration());
            BaseConfiguration.GetBaseProfileTypes().ForEach(x => serviceCollection.AddScoped(x));
            BaseConfiguration.GetBaseProfileTypes().ForEach(x =>
            {
                BaseConfiguration.AddBaseProfile((IBaseProfile) serviceCollection.BuildServiceProvider().GetService(x));
            });
        }

        public static void UseTyMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<CoreMiddleware>();
        }
    }
}