using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TrendyolMiddleware.BaseMiddleware;
using TrendyolMiddleware.Configuration;
using TrendyolMiddleware.Model;
using TrendyolMiddleware.Services.RestServices.HttpContexts;

namespace TrendyolMiddleware.Services.Middleware.CoreMiddleware
{
    public class MiddlewareService : IMiddlewareService
    {
        private readonly IHttpContextService _httpContextService;
        private MiddlewareInformation _middlewareInformation;
        private readonly List<IBaseMiddleware> _middlewares;
        private readonly MemoryStream _responseBody;
        private Stream _originalResponseBody;
        
        public MiddlewareService(IHttpContextService httpContextService)
        {
            _httpContextService = httpContextService;
            _responseBody = new MemoryStream();
            _middlewares = BaseConfiguration.GetMiddlewares();
        }
        public async Task BeforeDelegateHandler(HttpContext httpContext)
        {
            SaveResponsePosition(httpContext);
            await InitializeMiddlewareInformationAsync(httpContext);
            _middlewares.ForEach(async (x) => await x.BeforeDelegateHandle(_middlewareInformation));
        }

        public async Task AfterDelegateHandler(HttpContext httpContext)
        {
            await SetResponseMiddlewareInformationAsync(httpContext);
            await _responseBody.CopyToAsync(_originalResponseBody);
            _middlewares.ForEach(async (x) => await x.AfterDelegateHandle(_middlewareInformation));
        }
        
        public Task ExceptionHandler(HttpContext httpContext, Exception exception)
        {
            throw new System.NotImplementedException();
        }
        
        private async Task InitializeMiddlewareInformationAsync(HttpContext httpContext)
        {
            _middlewareInformation = new MiddlewareInformation
            {
                Id = Guid.NewGuid().ToString(),
                RequestBody = await _httpContextService.GetRequestBody(httpContext),
                HttpMethod = _httpContextService.GetRequestMethod(httpContext),
                CallDate = DateTime.Now,
                Headers = GetRequestHeaders(httpContext),
            };
        }
        
        private async Task SetResponseMiddlewareInformationAsync(HttpContext httpContext)
        {
            _middlewareInformation.ResponseBody = await _httpContextService.GetResponseBody(httpContext);
            _middlewareInformation.ProcessingTime = DateTime.Now.Subtract(_middlewareInformation.CallDate).Milliseconds;
        }
        
        private Dictionary<string,string> GetRequestHeaders(HttpContext httpContext)
        {
            var headers = new Dictionary<string, string>();
            httpContext?.Request?.Headers.Keys.ToList().ForEach(x => headers.Add(x,httpContext.Request.Headers[x].ToString()));

            return headers;
        }
        
        private void SaveResponsePosition(HttpContext httpContext)
        {
            _originalResponseBody = httpContext.Response.Body;
            httpContext.Response.Body = _responseBody;
        }
    }
}