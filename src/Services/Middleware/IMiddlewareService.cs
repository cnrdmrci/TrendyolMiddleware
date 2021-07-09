using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TrendyolMiddleware.Services.Middleware
{
    public interface IMiddlewareService
    {
        Task RequestHandler(HttpContext httpContext);
        Task ResponseHandler(HttpContext httpContext);
        Task ExceptionHandler(HttpContext httpContext, Exception exception);
    }
}