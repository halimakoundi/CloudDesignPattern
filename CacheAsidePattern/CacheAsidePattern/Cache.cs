using ServiceStack.Redis;

namespace CacheAsidePattern
{
    public class Cache
    {
        private readonly string _host = "localhost:6379";

        public User GetCachedUser(string key)
        {
            using (var redisClient = new RedisClient(_host))
            {
                return new User { Id = key, Name = redisClient.Get<string>(GenerateKey(key)) };
            }
        }

        private static string GenerateKey(string dataId)
        {
            var generateKey = $"CachedData_{dataId}";
            return generateKey;
        }

        public bool CacheUser(User user)
        {
            using (var redisClient = new RedisClient(_host))
            {
                return redisClient.Set(GenerateKey(user.Id), user.Name);
            }
        }

        public void RemoveCachedData(string dataId)
        {
            using (var redisClient = new RedisClient(_host))
            {
                redisClient.Remove(GenerateKey(dataId));
            }
        }
    }
}