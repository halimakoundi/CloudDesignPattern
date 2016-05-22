using System;
using CacheAsidePattern;
using NUnit.Framework;
/*
 When data is not in store, the data is added to the store
 When data is in store, the data is retrieved from the store
 When data is modified , the data is removed from the store     
 */
namespace CacheAsideTests
{
    [TestFixture]
    public class CacheAsideShould
    {
        [Test]
        public void add_user_to_store_if_user_is_not_in_store()
        {
            var user = new User();
            var cacheAside = new CacheAside();

            var putUserInStore = cacheAside.PutDataInStore(user);

            Assert.That(putUserInStore, Is.True);
        }

        [TestCase(typeof(User), "testUserId1", false)]
        [TestCase(typeof(Book), "testBookId1", false)]
        public void not_add_data_to_the_cache_if_data_already_cached(
                    Type type, string dataId, bool expected)
        {                                               
            var cacheAside = new CacheAside();
            var data = (CachedData)Activator.CreateInstance(type);
            data.Id = dataId;

            var hasPutUserInStore = cacheAside.PutDataInStore(data);
                
            Assert.That(hasPutUserInStore, Is.EqualTo(expected));
        }
    }
}
