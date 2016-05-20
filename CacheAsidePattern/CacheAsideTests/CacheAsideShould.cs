﻿using NUnit.Framework;
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
        public void add_user_to_store_when_data_is_not_in_store()
        {
            var user = new User();
            var cacheAside = new CacheAside();

            var putUserInStore = cacheAside.PutDataInStore(user);

            Assert.That(putUserInStore, Is.EqualTo(true));
        }
    }
}
