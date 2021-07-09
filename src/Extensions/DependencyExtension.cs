using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TrendyolMiddleware.BaseMiddleware;
using TrendyolMiddleware.Configuration;
using TrendyolMiddleware.Registry;

namespace TrendyolMiddleware.Extensions
{
    public static class DependencyExtension
    {
        public static void AddTrendyolMiddleware(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterMiddlewareServices();
        }

        public static void UseTrendyolMiddleware(this IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseMiddleware<CoreMiddleware>();
        }
        
        public static void UseTrendyolMiddleware(this IApplicationBuilder applicationBuilder,Action<MiddlewareConfiguration> middlewareConfigurationAction)
        {
            middlewareConfigurationAction(new MiddlewareConfiguration());
            applicationBuilder.UseMiddleware<CoreMiddleware>();
        }
    }
}