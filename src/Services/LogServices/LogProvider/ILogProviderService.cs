namespace Trendyol.TyMiddleware.Services.LogServices.LogProvider
{
    public interface ILogProviderService
    {
        dynamic CreateLogObject(BaseMiddlewareModel baseMiddlewareModel);
    }
}