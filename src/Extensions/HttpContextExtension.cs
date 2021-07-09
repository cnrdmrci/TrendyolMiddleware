using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TrendyolMiddleware.Model;

namespace TrendyolMiddleware.Extensions
{
    public static class HttpContextExtension
    {
        public static async Task<string> RequestBody(this HttpContext httpContext)
        {
            httpContext.Request.EnableBuffering();
            var buffer = new byte[Convert.ToInt32(httpContext.Request.ContentLength)];
            await httpContext.Request.Body.ReadAsync(buffer, 0, buffer.Length);
            httpContext.Request.Body.Seek(0, SeekOrigin.Begin);
            
            return Encoding.UTF8.GetString(buffer);
        }
        
        public static async Task<string> ResponseBody(this HttpContext httpContext)
        {
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);
            var responseBody = await new StreamReader(httpContext.Response.Body).ReadToEndAsync();
            httpContext.Response.Body.Seek(0, SeekOrigin.Begin);

            return responseBody;
        }
        
        public static string RequestMethod(this HttpContext httpContext)
        {
            return httpContext.Request.Method;
        }
        
        public static Dictionary<string,string> RequestHeaders(this HttpContext httpContext)
        {
            var headers = new Dictionary<string, string>();
            httpContext?.Request?.Headers.Keys.ToList().ForEach(x => headers.Add(x,httpContext.Request.Headers[x].ToString()));

            return headers;
        }
        
        public static async Task SetResponseAsync(this HttpContext httpContext, BaseMiddlewareModel baseMiddlewareModel)
        {
            if (baseMiddlewareModel == null) throw new ArgumentNullException(nameof(baseMiddlewareModel));
            baseMiddlewareModel.ResponseBody = await httpContext.ResponseBody();
        }
        
        public static void SetProcessingTime(this HttpContext httpContext, BaseMiddlewareModel baseMiddlewareModel)
        {
            if (baseMiddlewareModel == null) throw new ArgumentNullException(nameof(baseMiddlewareModel));
            baseMiddlewareModel.ProcessingTime = DateTime.Now.Subtract(baseMiddlewareModel.CallDate).Milliseconds;
        } 
    }
}