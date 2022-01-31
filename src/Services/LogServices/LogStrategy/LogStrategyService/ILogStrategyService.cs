namespace Trendyol.TyMiddleware.Services.LogServices.LogStrategy.LogStrategyService
{
    public interface ILogStrategyService
    {
        LogType LogType { get; }
        void SaveLog(dynamic logObject);
    }
}