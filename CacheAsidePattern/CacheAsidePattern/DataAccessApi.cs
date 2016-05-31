namespace CacheAsidePattern
{
    public class DataAccessApi
    {
        private DataStore _dataStore;

        public User GetUserById(string dataId)
        {
            _dataStore = new DataStore();
            var user = (User)new User {Id = dataId}.GetCachedData();
            if (user != null) return user;
            user= _dataStore.LoadUser(dataId);
            PutDataInCahe(user);
            return user;
        }

        private static bool PutDataInCahe(CachedData data)
        {
            return data.CacheData();
        }

        public void SaveData(CachedData data)
        {
            _dataStore.Save(data);
            RemoveDataFromCache(data);
        }

        private void RemoveDataFromCache(CachedData data)
        {
            data.RemoveFromCache();
        }
    }
}