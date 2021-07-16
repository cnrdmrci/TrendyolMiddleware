namespace Trendyol.TyMiddleware.Services.LogServices.LogMiddlewareFilter
{
    public interface ILogProfileService
    {
        bool IsLoggingIgnore(BaseMiddlewareModel baseMiddlewareModel);
        LogMiddlewareProfile GetLogMiddlewareProfile();
        ApiFilter GetApiFilter(BaseMiddlewareModel baseMiddlewareModel);
    }
}