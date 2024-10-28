using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace ADO_Dapper_ServiceManagment.DAL.utils
{
    public class CacheHelper
    {

        public static void Invalidate(IMemoryCache cache, ILogger logger, params string[] keys)
        {
            foreach (string key in keys)
            {
                logger.LogInformation($"Ivalidating cache for key {key}");
                cache.Remove(key);
            }
        }

        public static T? GetOrSet<T>(string key, Func<T> task, IMemoryCache cache, ILogger logger, MemoryCacheEntryOptions? options = null)
        {
            if (options == null)
            {
                options = new MemoryCacheEntryOptions()
                   .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                   .SetAbsoluteExpiration(TimeSpan.FromMinutes(120))
                   .SetPriority(CacheItemPriority.NeverRemove)
                   .SetSize(2048);
            }

            if (!cache.TryGetValue(key, out T? entities))
            {
                logger.LogInformation($"Cache is missing. Fetching data for key: {key} from database.", key);

                entities = task();

                if (entities != null)
                {
                    logger.LogInformation($"Setting data for key: {key} to cache.", key);
                    cache.Set(key, entities, options);
                }
            }
            else
            {
                logger.LogInformation($"Fetching data from cache for key {key}");
            }

            return entities;
        }
    }
}
