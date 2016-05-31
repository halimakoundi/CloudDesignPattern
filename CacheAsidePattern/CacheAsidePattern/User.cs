namespace CacheAsidePattern
{
    public class User : CachedData
    {
        public string Id { get; set; }
        public string Name { get; set; } = "Unknown User";

        public bool CacheData()
        {
            return new Cache().CacheUser(this);
        }

        public CachedData GetCachedData()
        {
            return new Cache().GetCachedUser(this.Id);
        }
    }
}