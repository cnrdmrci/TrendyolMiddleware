using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TrendyolMiddleware.Services.Middleware.CoreMiddleware
{
    public interface IMiddlewareService
    {
        Task BeforeDelegateHandler(HttpContext httpContext);
        Task AfterDelegateHandler(HttpContext httpContext);
        Task ExceptionHandler(HttpContext httpContext, Exception exception);
    }
}