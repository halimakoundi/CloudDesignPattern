﻿using CacheAsidePattern;
using NUnit.Framework;
/*
 When data is fetched and not in store, the data is added to the store, then the data is retrieved from the store
 When data is modified , the data is removed from the store     
 */
namespace CacheAsideTests
{
    [TestFixture]
    public class CacheAsideShould
    {
        [Test]
        public void add_user_to_cache_if_user_is_not_in_cache()
        {
            var cacheAside = new DataAccessApi();
            var userId= "testUserId1";

            var user = cacheAside.GetUserById(userId);
            
            Assert.That(user, Is.Not.Null);
        }


    }
}
