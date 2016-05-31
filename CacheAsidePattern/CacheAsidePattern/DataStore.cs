namespace CacheAsidePattern
{
    internal class DataStore
    {
        public User LoadUser(string dataId)
        {
            //Faking data Store
            return new User { Id = dataId };
        }

        public void Save(CachedData data)
        {
            //Faking data store save data
        }
    }
}