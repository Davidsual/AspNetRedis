using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using RedisSessionProvider.Config;
using StackExchange.Redis;
using RedisSessionProvider.Config;
using StackExchange.Redis;
namespace DavideTrotta.AspNet.Redis.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static ConfigurationOptions redisConfigOpts;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            // assign your local Redis instance address, can be static
            MvcApplication.redisConfigOpts = ConfigurationOptions.Parse("127.0.0.1:6379");

            // pass it to RedisSessionProvider configuration class
            RedisConnectionConfig.GetSERedisServerConfig = (HttpContextBase context) =>
            {
                return new KeyValuePair<string, ConfigurationOptions>(
                    "DefaultConnection",				// if you use multiple configuration objects, please make the keys unique
                    MvcApplication.redisConfigOpts);
            };
        }
    }
}
