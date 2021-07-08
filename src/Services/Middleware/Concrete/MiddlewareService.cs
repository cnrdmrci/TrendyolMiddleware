using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using TrendyolMiddleware.MiddlewareManagement.Configuration;
using TrendyolMiddleware.Model;
using TrendyolMiddleware.Services.RestServices.HttpContexts;

namespace TrendyolMiddleware.Services.Middleware
{
    public class MiddlewareService : IMiddlewareService
    {
        private MiddlewareInformation _middlewareInformation;
        private readonly IHttpContextService _httpContextService;
        private readonly IConfigurationManagementService _configurationManagementService;
        private MemoryStream _responseBody;
        private Stream _originalResponseBody;

        public MiddlewareService(IHttpContextService httpContextService, IConfigurationManagementService configurationManagementService)
        {
            _httpContextService = httpContextService;
            _configurationManagementService = configurationManagementService;
            _responseBody = new MemoryStream();
        }
        public async Task BeforeDelegateHandler(HttpContext httpContext)
        {
            await InitializeMiddlewareInformationAsync(httpContext);
            _originalResponseBody = httpContext.Response.Body;
            httpContext.Response.Body = _responseBody;
            var delegateHandlers = _configurationManagementService.GetMiddlewareDelegateHandlers();
            foreach (var delegateHandler in delegateHandlers)
            {
                await delegateHandler.BeforeDelegateHandle(_middlewareInformation);
            }
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

        public async Task AfterDelegateHandler(HttpContext httpContext)
        {
            
            await SetResponseMiddlewareInformationAsync(httpContext);
            await _responseBody.CopyToAsync(_originalResponseBody);
            var delegateHandlers = _configurationManagementService.GetMiddlewareDelegateHandlers();
            foreach (var delegateHandler in delegateHandlers)
            {
                await delegateHandler.AfterDelegateHandle(_middlewareInformation);
            }
        }

        private async Task SetResponseMiddlewareInformationAsync(HttpContext httpContext)
        {
            _middlewareInformation.ResponseBody = await _httpContextService.GetResponseBody(httpContext);
            _middlewareInformation.ProcessingTime = (DateTime.Now - _middlewareInformation.CallDate).Milliseconds;
        }

        public Task ExceptionHandler(HttpContext httpContext, Exception exception)
        {
            throw new System.NotImplementedException();
        }
        
        public string GetRequestHeaders(HttpContext httpContext)
        {
            if (httpContext?.Request?.Headers == null)
            {
                return string.Empty;
            }
            var headers = string.Empty;
            foreach (var key in httpContext.Request.Headers.Keys)
            {
                var value = httpContext.Request.Headers[key].ToString();
                headers += string.Format("{0}: {1}", key, string.Join(",", value));
            }

            return headers;
        }
    }
}