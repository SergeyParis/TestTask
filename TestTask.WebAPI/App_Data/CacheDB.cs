using System;
//remove line
using TestTask.SDK;
using TestTask.SDK.Models;
//namespace
namespace TestTask.WebAPI
{
    //it is not used, remove it
    //your solution should not contain any not used/not implement code
    //it should not be here, it must be placed in SDK
    internal sealed class CacheDB : ICacher
    {
        private readonly FeedContext _db;

        public CacheDB()
        {
            _db = new FeedContext();
        }

        //Not used
        public IFeed<IItem> GetCollection(string Id)
        {
            
        }
        public long GetTimeExistCacheMiliseconds(string Id) => throw new NotImplementedException();
        public string AddFeedIntoCollection(string collectionId, IItem feed) => throw new NotImplementedException();

        //change name, it is not clear
        public void CachingCollection(IFeed<IItem> collection) => throw new NotImplementedException();
        public bool TryLoadFromCache(string Id, out IFeed<IItem> collection) => throw new NotImplementedException();
    }
}