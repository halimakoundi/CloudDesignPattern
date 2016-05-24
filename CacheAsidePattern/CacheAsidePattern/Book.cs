namespace CacheAsidePattern
{
    public class Book : CachedData
    {
        public string Id { get; set; }
        public string Title { get; set; }

        public bool CacheData()
        {
            return new Cache().CacheBook(this);
        }

        public CachedData GetCachedData()
        {
            return new Cache().GetCachedBook(this.Id);
        }
    }
}