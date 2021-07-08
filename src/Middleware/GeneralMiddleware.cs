using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TrendyolMiddleware.Services.Middleware;

namespace TrendyolMiddleware.Middleware
{
    public class GeneralMiddleware
    {
        private readonly RequestDelegate _next;

        public GeneralMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext httpContext, IMiddlewareService middlewareService)
        {
            try
            {
                await middlewareService.BeforeDelegateHandler(httpContext);
                await _next(httpContext);
                await middlewareService.AfterDelegateHandler(httpContext);
            }
            catch (Exception exception)
            {
                await middlewareService.ExceptionHandler(httpContext,exception);
                throw;
            }
            
        }
    }
}