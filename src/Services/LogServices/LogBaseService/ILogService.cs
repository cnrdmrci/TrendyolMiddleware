namespace Trendyol.TyMiddleware.Services.LogServices.LogBaseService
{
    public interface ILogService
    {
        void Log(BaseMiddlewareModel baseMiddlewareModel);
        bool IgnoreLog(BaseMiddlewareModel baseMiddlewareModel);
    }
}