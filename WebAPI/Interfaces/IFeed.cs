using System;
using System.Collections.Generic;

//fix namespace
namespace TestTask.SDK.Models
{
    //property declarations and 
    //AddFeed, GetFeeds, GetFeed methods 
    //should be splitted into 2 different interfaces
    //i.e. IFeedModel, IFeedOperations
    public interface IFeed<out TElement> : IEnumerable<TElement>
        where TElement : IItem
    {
        string Id { get; }
        string Name { get; }
        string Title { get; }
        string Language { get; }
        DateTime LastUpdatedTime { get; }

        string AddFeed(IItem element);
        IEnumerable<TElement> GetFeeds();
        
        TElement GetFeed(string id);
    }
}
