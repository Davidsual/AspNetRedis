# AspNetRedis
Integration Asp,Net MVC 5 + Redis (DB nosql memory) + custom session provider


A barebone project that integrate Asp.Net MVC 5 and Redis database as custom session storage.

Redis is an open source, BSD licensed, advanced key-value cache and store. It is often referred to as a data structure server since keys can contain strings, hashes, lists, sets, sorted sets, bitmaps and hyperloglogs.

I used redis as custom session storage.

I used NUGET RedisSessionProvider provided by microsoft for write session in redis.

  <b>Web.Config:</b>
    <sessionState mode="Custom" customProvider="RedisSessionProvider">      
      <providers>
        <add 
          name="RedisSessionProvider" type="RedisSessionProvider.RedisSessionStateStoreProvider, RedisSessionProvider" />
      </providers>
    </sessionState>
    
    <b>Global.Asax:</b>
    public class MvcApplication : System.Web.HttpApplication
    {
        private static ConfigurationOptions redisConfigOpts;

        protected void Application_Start()
        {
            ...

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
    
    <b>Controller:</b>
    Session[SessionName] = "My value";
    
    easy peasy...
    
    <b>Why Redis?</b> 
    Well in a web farm with a load balancer without stiky session we need to centralize our Session... or eventually Cache...     Redis perform very well in high volume of writing / reading. Redis is a Key/Value based.. and of course it must be           deployed on a third box (better linux).
    
    Perfect for session / cache / or state storage....extremely useful for Web.Api
    
    
    
