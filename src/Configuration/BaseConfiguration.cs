using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Trendyol.TyMiddleware.BaseMiddleware;
using Trendyol.TyMiddleware.Profile;

namespace Trendyol.TyMiddleware.Configuration
{
    public static class BaseConfiguration
    {
        private static readonly List<IBaseMiddleware> BaseMiddlewares;
        private static readonly List<IBaseProfile> BaseProfiles;
        private static readonly List<Type> BaseProfileTypes;
        private static readonly IEnumerable<Type> MiddlewareProfileTypes;

        static BaseConfiguration()
        {
            BaseMiddlewares = new List<IBaseMiddleware>();
            BaseProfiles = new List<IBaseProfile>();
            BaseProfileTypes = new List<Type>();
            MiddlewareProfileTypes = GetMiddlewareProfileTypes();
        }

        private static IEnumerable<Type> GetMiddlewareProfileTypes()
        {
            return Assembly.GetEntryAssembly()?.GetTypes()
                .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(LogMiddlewareProfile)));
        }

        public static void AddMiddleware(IBaseMiddleware baseMiddleware)
        {
            BaseMiddlewares.Add(baseMiddleware);
        }

        public static void AddType(Type type)
        {
            Type profileType = MiddlewareProfileTypes?.FirstOrDefault(x => x.Name == type.Name);
            if (profileType == null)
            {
                throw new Exception($"Profile({type.Name}) not found.");
            }
            
            BaseProfileTypes.Add(type);
        }
        
        public static void AddBaseProfile(IBaseProfile baseProfile)
        {
            BaseProfiles.Add(baseProfile);
            
            AddMiddlewareForProfile(baseProfile);
        }

        private static void AddMiddlewareForProfile(IBaseProfile baseProfile)
        {
            var baseMiddleware = ProfileCoupling.GetBaseMiddleware(baseProfile);
            if (baseMiddleware == null) return;
            
            AddMiddleware(baseMiddleware);
        }

        public static void AddMiddlewares(List<IBaseMiddleware> baseMiddlewares)
        {
            BaseMiddlewares.AddRange(baseMiddlewares);
        }

        public static List<IBaseMiddleware> GetMiddlewares()
        {
            return BaseMiddlewares;
        }

        public static List<IBaseProfile> GetBaseProfiles()
        {
            return BaseProfiles;
        }

        public static List<Type> GetBaseProfileTypes()
        {
            return BaseProfileTypes;
        }
    }
}