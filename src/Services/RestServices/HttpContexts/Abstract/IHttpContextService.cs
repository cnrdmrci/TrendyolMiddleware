using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TrendyolMiddleware.Services.RestServices.HttpContexts
{
    public interface IHttpContextService
    {
        Task<string> GetRequestBody(HttpContext httpContext);
        Task<string> GetResponseBody(HttpContext httpContext);
        string GetRequestMethod(HttpContext httpContext);
    }
}