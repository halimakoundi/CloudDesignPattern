namespace CacheAsidePattern
{
    public class CacheAside
    {
        public bool PutDataInStore(CachedData data)
        {
            var cache= new Cache ();
            var cachedData = data.GetCachedData();
            return true;
        }

    }
}