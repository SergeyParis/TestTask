using System;
using System.Collections.Generic;

using TestTask.SDK.Models;
//namespace + usings
namespace TestTask.SDK
{
    //rename Id to id in input paramters
    public interface ICacher
    {
        //this name is not cler
        void CachingCollection(IFeed<IItem> collection);
        bool TryLoadFromCache(string Id, out IFeed<IItem> collection);//you do not use it, remove
        IFeed<IItem> GetCollection(string Id);

        string AddFeedIntoCollection(string collectionId, IItem feed);

        long GetTimeExistCacheMiliseconds(string Id);
    }
}
