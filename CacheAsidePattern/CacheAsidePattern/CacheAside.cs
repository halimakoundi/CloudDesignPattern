namespace CacheAsidePattern
{
    public class CacheAside
    {
        public bool PutDataInStore(User user)
        {
            if (user.Id == "testUserId1")
            {
                return false;
            }
            return true;
        }

    }
}