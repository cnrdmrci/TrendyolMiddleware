using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Trendyol.TyMiddleware.Core.MiddlewareCoreProcessService
{
    public interface IMiddlewareService
    {
        Task RequestHandler(HttpContext httpContext);
        Task ResponseHandler(HttpContext httpContext);
        Task ExceptionHandler(HttpContext httpContext, Exception exception);
    }
}