using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Events.BLL.Utils
{
    public static class DistributedCacheExtensions
    {
        private static JsonSerializerOptions serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null,
            WriteIndented = true,
            AllowTrailingCommas = true,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            ReferenceHandler = ReferenceHandler.Preserve
        };

        public static Task SetAsync<T>(this IDistributedCache cache, string key, T value, DistributedCacheEntryOptions? options = null)
        {
            if(options == null)
            {
                options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30))
                    .SetAbsoluteExpiration(TimeSpan.FromHours(1));
            }
            var bytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value, serializerOptions));
            return cache.SetAsync(key, bytes, options);
        }

        public static bool TryGetValue<T>(this IDistributedCache cache, string key, out T? value)
        {
            var val = cache.Get(key);
            value = default;
            if (val == null) return false;
            value = JsonSerializer.Deserialize<T>(val, serializerOptions);
            return true;
        }

        public static async Task Invalidate(this IDistributedCache cache, ILogger logger, params string[] keys)
        {
            foreach (string key in keys)
            {
                logger.LogInformation($"Ivalidating cache for key {key}");
                await cache.RemoveAsync(key);
            }
        }

        public static async Task<T?> GetOrSetAsyn<T>(this IDistributedCache cache, string key, Func<Task<T>> task, ILogger logger, DistributedCacheEntryOptions? options = null)
        {
            if (!TryGetValue(cache, key, out T? entities))
            {
                logger.LogInformation($"Cache is missing. Fetching data for key: {key} from database.", key);

                entities = await task();

                if (entities != null)
                {
                    logger.LogInformation($"Setting data for key: {key} to cache.", key);
                    await SetAsync(cache, key, entities, options);
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
