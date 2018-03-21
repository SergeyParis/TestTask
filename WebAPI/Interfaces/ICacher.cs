using System;
using System.Collections.Generic;

using TestTask.SDK.Models;

namespace TestTask.SDK
{
    public interface ICacher
    {
        void CachingCollection(IFeedCollection<IFeed> collection);
        bool TryLoadFromCache(string Id, out IFeedCollection<IFeed> collection);
        IFeedCollection<IFeed> GetCollection(string Id);

        string AddFeedIntoCollection(string collectionId, IFeed feed);

        long GetTimeExistCacheMiliseconds(string Id);
    }
}
