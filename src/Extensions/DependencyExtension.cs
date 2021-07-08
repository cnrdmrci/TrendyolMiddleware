using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TrendyolMiddleware.Middleware;
using TrendyolMiddleware.MiddlewareManagement.Configuration;
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
            applicationBuilder.UseMiddleware<GeneralMiddleware>();
            
        }
    }
}