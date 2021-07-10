using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Trendyol.TyMiddleware.Services.Middleware;

namespace Trendyol.TyMiddleware.BaseMiddleware
{
    public class CoreMiddleware
    {
        private readonly RequestDelegate _next;

        public CoreMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        
        public async Task Invoke(HttpContext httpContext, IMiddlewareService middlewareService)
        {
            try
            {
                await middlewareService.RequestHandler(httpContext);
                await _next(httpContext);
                await middlewareService.ResponseHandler(httpContext);
            }
            catch (Exception exception)
            {
                await middlewareService.ExceptionHandler(httpContext,exception);
                throw;
            }
        }
    }
}