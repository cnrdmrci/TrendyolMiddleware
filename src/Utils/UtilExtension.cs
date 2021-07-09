using System.Collections.Generic;
using System.Linq;
using TrendyolMiddleware.Outputs.Logging.LogConfig;

namespace TrendyolMiddleware.Utils
{
    public static class UtilExtension
    {
        public static bool AnyNullSafe<T>(this List<T> list) 
        {
            return list != null && list.Any();
        }
        
        public static bool IsNullOrEmpty<T>(this List<T> list) 
        {
            return list == null || !list.Any();
        }
    }
}