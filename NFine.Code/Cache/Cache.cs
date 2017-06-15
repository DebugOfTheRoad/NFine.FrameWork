using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NFine.Code.Cache
{
    public class Cache : ICache
    {
        private static System.Web.Caching.Cache cache = HttpRuntime.Cache;

        public T GetCache<T>(string cacheKey) where T : class
        {
            if (cache[cacheKey] == null)
            {
                throw new Exception("未能在缓存中找到相应的键值");
            }
            return (T)cache[cacheKey];
        }

        public void RemoveCache(string cacheKey)
        {
            cache.Remove(cacheKey);
        }

        public void RemoveCache()
        {
            IDictionaryEnumerator cacheEnum = cache.GetEnumerator();
            while (cacheEnum.MoveNext())
            {
                cache.Remove(cacheEnum.Key.ToString());
            }
        }

        public void WriteCache<T>(T value, string cacheKey) where T : class
        {
            cache.Insert(cacheKey, value, null,
                DateTime.Now.AddMinutes(10),
                System.Web.Caching.Cache.NoSlidingExpiration);
        }

        public void WriteCache<T>(T value, string cacheKey, DateTime expireTime) where T : class
        {
            cache.Insert(cacheKey, value, null,
                expireTime,
                System.Web.Caching.Cache.NoSlidingExpiration);
        }
    }
}
