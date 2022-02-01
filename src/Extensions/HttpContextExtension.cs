using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

#if NETCOREAPP3_1_OR_GREATER
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
#endif

namespace Trendyol.TyMiddleware.Extensions
{
    public static class HttpContextExtension
    {
        public static async Task<string> GetRequestBody(this HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(httpContext.Request.ContentLength)];
            await httpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            
            return Encoding.UTF8.GetString(buffer);
        }
        
        public static async Task<string> GetResponseBody(this HttpContext httpContext)
        {
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

            return responseBody;
        }
        
        public static string GetRequestMethod(this HttpContext httpContext)
        {
            return httpContext.Request.Method;
        }
        
        public static Dictionary<string,string> GetRequestHeaders(this HttpContext httpContext)
        {
            var headers = new Dictionary<string, string>();
            httpContext?.Request?.Headers.Keys.ToList().ForEach(x => headers.Add(x,httpContext.Request.Headers[x].ToString()));

            return headers;
        }
        
        public static async Task SetResponseAsync(this HttpContext httpContext, BaseMiddlewareModel baseMiddlewareModel)
        {
            if (baseMiddlewareModel == null) throw new ArgumentNullException(nameof(baseMiddlewareModel));
            baseMiddlewareModel.ResponseBody = await httpContext.GetResponseBody();
        }
        
        public static void SetProcessingTime(this HttpContext httpContext, BaseMiddlewareModel baseMiddlewareModel)
        {
            if (baseMiddlewareModel == null) throw new ArgumentNullException(nameof(baseMiddlewareModel));
            baseMiddlewareModel.ProcessingTime = DateTime.Now.Subtract(baseMiddlewareModel.CallDate).Milliseconds;
        }

        public static string GetControllerName(this HttpContext httpContext)
        {
#if NETCOREAPP3_1_OR_GREATER
            var controllerActionDescriptor = httpContext
                .GetEndpoint()?
                .Metadata
                .GetMetadata<ControllerActionDescriptor>();
            return controllerActionDescriptor?.ControllerName ?? string.Empty;
#else
            return "Not supported below .net core 3.1 for ControllerName";
#endif
        }

        public static string GetActionName(this HttpContext httpContext)
        {
#if NETCOREAPP3_1_OR_GREATER
            var controllerActionDescriptor = httpContext
                .GetEndpoint()?
                .Metadata
                .GetMetadata<ControllerActionDescriptor>();
            return controllerActionDescriptor?.ActionName ?? string.Empty;
#else
            return "Not supported below .net core 3.1 for ActionName";
#endif
        }

        public static string GetFullAction(this HttpContext httpContext)
        {
            return System.Reflection.Assembly.GetEntryAssembly()?.GetName().Name + httpContext.Request.Path;
        }
        
        public static string GetRequestUri(this HttpContext httpContext)
        {
            HttpRequest request = httpContext.Request;
            return $"{request.Scheme + "://"}{request.Host}{request.Path}{request.QueryString}";
        }

        public static int GetResponseStatusCode(this HttpContext httpContext)
        {
            return httpContext.Response.StatusCode;
        }
    }
}