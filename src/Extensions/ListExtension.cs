using System.Collections.Generic;
using System.Linq;

namespace Trendyol.TyMiddleware.Extensions
{
    public static class ListExtension
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