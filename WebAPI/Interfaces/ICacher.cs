using System;
using System.Collections.Generic;

using TestTask.SDK.Models;

namespace TestTask.SDK
{
    public interface ICacher
    {
        void CachingCollection(IFeed<IItem> collection);
        bool TryLoadFromCache(string Id, out IFeed<IItem> collection);
        IFeed<IItem> GetCollection(string Id);

        string AddFeedIntoCollection(string collectionId, IItem feed);

        long GetTimeExistCacheMiliseconds(string Id);
    }
}
