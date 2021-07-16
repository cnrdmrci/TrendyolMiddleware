using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Trendyol.TyMiddleware.Configuration;
using Trendyol.TyMiddleware.Core.MiddlewareCoreProvider;
using Trendyol.TyMiddleware.Extensions;

namespace Trendyol.TyMiddleware.Core.MiddlewareCoreProcessService
{
    public class MiddlewareService : IMiddlewareService
    {
        private BaseMiddlewareModel _baseMiddlewareModel;
        private readonly List<IBaseMiddleware> _middlewares;
        private readonly MemoryStream _responseBody;
        private Stream _pureResponseBody;
        
        public MiddlewareService(IServiceProvider serviceProvider)
        {
            _responseBody = new MemoryStream();
            _middlewares = BaseConfiguration.GetMiddlewareTypes().CreateServices(serviceProvider);
        }
        public async Task RequestHandler(HttpContext httpContext)
        {
            CacheResponseBodyPointer(httpContext);
            await InitializeBaseMiddlewareModelAsync(httpContext);
            _middlewares.ForEach(async (x) => await x.RequestHandler(_baseMiddlewareModel));
        }

        public async Task ResponseHandler(HttpContext httpContext)
        {
            await SetResponseInformationToMiddlewareModel(httpContext);
            await CopyResponseBodyToOriginalOffset();
            _middlewares.ForEach(async (x) => await x.ResponseHandler(_baseMiddlewareModel));
        }

        private async Task CopyResponseBodyToOriginalOffset()
        {
            await _responseBody.CopyToAsync(_pureResponseBody);
        }

        private async Task SetResponseInformationToMiddlewareModel(HttpContext httpContext)
        {
            httpContext.SetProcessingTime(_baseMiddlewareModel);
            await httpContext.SetResponseAsync(_baseMiddlewareModel);
        }

        public Task ExceptionHandler(HttpContext httpContext, Exception exception)
        {
            Console.WriteLine(exception.Message);
            throw new System.NotImplementedException();
        }
        
        private async Task InitializeBaseMiddlewareModelAsync(HttpContext httpContext)
        {
            _baseMiddlewareModel = new BaseMiddlewareModel
            {
                Id = Guid.NewGuid().ToString(),
                RequestBody = await httpContext.GetRequestBody(),
                HttpMethod = httpContext.GetRequestMethod(),
                CallDate = DateTime.Now,
                Headers = httpContext.GetRequestHeaders(),
                Controller = httpContext.GetControllerName(),
                Action = httpContext.GetActionName(),
                FullAction = httpContext.GetFullAction(),
                RequestUri = httpContext.GetRequestUri(),
                ResponseStatusCode = httpContext.GetResponseStatusCode()
            };
        }
 
        private void CacheResponseBodyPointer(HttpContext httpContext)
        {
            if (_responseBody == null) throw new ArgumentNullException(nameof(_responseBody));
            
            _pureResponseBody = httpContext.Response.Body;
            httpContext.Response.Body = _responseBody;
        }
    }
}