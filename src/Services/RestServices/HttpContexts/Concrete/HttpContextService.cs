using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace TrendyolMiddleware.Services.RestServices.HttpContexts
{
    public class HttpContextService : IHttpContextService
    {
        public async Task<string> GetRequestBody(HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(httpContext.Request.ContentLength)];
            await httpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            return Encoding.UTF8.GetString(buffer);
        }

        public async Task<string> GetResponseBody(HttpContext httpContext)
        {
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            string responseBody = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            
            return responseBody;
        }

        public string GetRequestMethod(HttpContext httpContext)
        {
            return httpContext.Request.Method;
        }
    }
}