namespace CacheAsidePattern
{
    public class User : CachedData
    {
        public User()
        {
        }

        public string Id { get; set; }
        public CachedData GetCachedData()
        {
            return new Cache().GetCachedUser(this.Id);
        }
    }
}