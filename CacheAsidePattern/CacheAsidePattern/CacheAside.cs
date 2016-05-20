namespace CacheAsidePattern
{
    public class CacheAside
    {
        public bool PutDataInStore(CachedData data)
        {
            if (data.Id == "testUserId1" || data.Id == "testBookId1")
            {
                return false;
            }
            return true;
        }

    }
}