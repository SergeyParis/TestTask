using System;

using TestTask.SDK;
using TestTask.SDK.Models;

namespace TestTask.WebAPI
{
    internal sealed class CacheDB : ICacher
    {
        public string AddFeedIntoCollection(string collectionId, IFeed feed) => throw new NotImplementedException();
        public void CachingCollection(IFeedCollection<IFeed> collection) => throw new NotImplementedException();
        public IFeedCollection<IFeed> GetCollection(string Id) => throw new NotImplementedException();
        public long GetTimeExistCacheMiliseconds(string Id) => throw new NotImplementedException();
        public bool TryLoadFromCache(string Id, out IFeedCollection<IFeed> collection) => throw new NotImplementedException();
    }
}