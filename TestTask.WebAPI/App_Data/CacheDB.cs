using System;

using TestTask.SDK;
using TestTask.SDK.Models;

namespace TestTask.WebAPI
{
    internal sealed class CacheDB : ICacher
    {
        private readonly FeedContext _db;

        public CacheDB()
        {
            _db = new FeedContext();
        }


        public IFeed<IItem> GetCollection(string Id)
        {
            
        }
        public long GetTimeExistCacheMiliseconds(string Id) => throw new NotImplementedException();
        public string AddFeedIntoCollection(string collectionId, IItem feed) => throw new NotImplementedException();
        public void CachingCollection(IFeed<IItem> collection) => throw new NotImplementedException();
        public bool TryLoadFromCache(string Id, out IFeed<IItem> collection) => throw new NotImplementedException();
    }
}