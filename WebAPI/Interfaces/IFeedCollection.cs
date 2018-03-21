using System;
using System.Collections.Generic;

namespace TestTask.SDK.Models
{
    public interface IFeedCollection<out TElement> : IEnumerable<TElement>
        where TElement : IFeed
    {
        string Id { get; }
        string Name { get; }
        string Title { get; }
        string Language { get; }
        DateTime LastUpdatedTime { get; }

        string AddFeed(IFeed element);
        IEnumerable<TElement> GetFeeds();
        
        TElement GetFeed(string id);
    }
}
