using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Trendyol.TyMiddleware.Configuration
{
    public static class BaseConfiguration
    {
        private static readonly List<Type> BaseMiddlewareTypes;
        private static readonly List<IBaseProfile> BaseProfiles;
        private static readonly List<Type> BaseProfileTypes;
        private static readonly IEnumerable<Type> MiddlewareProfileTypes;

        static BaseConfiguration()
        {
            BaseMiddlewareTypes = new List<Type>();
            BaseProfiles = new List<IBaseProfile>();
            BaseProfileTypes = new List<Type>();
            MiddlewareProfileTypes = GetMiddlewareProfileTypes();
        }

        private static IEnumerable<Type> GetMiddlewareProfileTypes()
        {
            return Assembly
                .GetEntryAssembly()?
                .GetTypes()
                .Where(myType =>
                    myType.IsClass &&
                    !myType.IsAbstract &&
                    myType.IsSubclassOf(typeof(LogMiddlewareProfile))
                );
        }

        public static void AddMiddlewareType(Type baseMiddlewareType)
        {
            BaseMiddlewareTypes.Add(baseMiddlewareType);
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
            AddMiddlewareType(baseProfile.GetMiddlewareType());
        }

        public static void AddMiddlewares(List<Type> baseMiddlewareTypes)
        {
            BaseMiddlewareTypes.AddRange(baseMiddlewareTypes);
        }

        public static List<Type> GetMiddlewareTypes()
        {
            return BaseMiddlewareTypes;
        }

        public static List<IBaseProfile> GetBaseProfiles()
        {
            return BaseProfiles;
        }

        public static T GetProfile<T>() where T : IBaseProfile
        {
            return GetBaseProfiles().OfType<T>().FirstOrDefault();
        }

        public static List<Type> GetBaseProfileTypes()
        {
            return BaseProfileTypes;
        }
    }
}