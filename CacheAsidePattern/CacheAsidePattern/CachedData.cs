namespace CacheAsidePattern
{
    public interface CachedData
    {
        string Id { get; set; }
        bool CacheData();
        void RemoveFromCache();
    }
}