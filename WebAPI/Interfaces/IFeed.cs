using System;
using System.Collections.Generic;

namespace TestTask.SDK.Models
{
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
