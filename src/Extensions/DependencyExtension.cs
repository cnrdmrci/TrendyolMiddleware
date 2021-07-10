using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Trendyol.TyMiddleware.BaseMiddleware;
using Trendyol.TyMiddleware.Configuration;
using Trendyol.TyMiddleware.Registry;

namespace Trendyol.TyMiddleware.Extensions
{
    public static class DependencyExtension
    {
        public static void AddTrendyolMiddleware(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterMiddlewareServices();
        }

        public static void UseTyMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<CoreMiddleware>();
        }
        
        public static void UseTyMiddleware(this IApplicationBuilder applicationBuilder,Action<MiddlewareConfiguration> middlewareConfigurationAction)
        {
            middlewareConfigurationAction(new MiddlewareConfiguration());
            applicationBuilder.UseMiddleware<CoreMiddleware>();
        }
    }
}