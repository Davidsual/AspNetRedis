using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.Redis;

namespace DavideTrotta.AspNet.Redis.Web.Services
{
    public interface ICacheProvider
    {
        T Get<T>(string key);
        void Set<T>(string key, T value);
    }

    public class CacheProvider : ICacheProvider
    {
        public T Get<T>(string key)
        {
            using(var client = new RedisClient(new RedisEndpoint("127.0.0.1",6379)))
            {
                if (!client.ContainsKey(key))
                    return default(T);

                return client.Get<T>(key);
            }
        }

        public void Set<T>(string key, T value)
        {
            using (var client = new RedisClient(new RedisEndpoint("127.0.0.1", 6379)))
            {
                client.Set(key, value);
            }
        }
    }
}