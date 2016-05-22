namespace CacheAsidePattern
{
    public class Book : CachedData
    {
        public Book()
        {
        }

        public string Id { get; set; }
        public CachedData GetCachedData()
        {
            return new Cache().GetCachedBook(this.Id);
        }
    }
}