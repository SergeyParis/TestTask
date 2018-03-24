using System;
using System.Collections.Generic;

namespace TestTask.SDK
{
    public interface IFeed<out TElement> : IEnumerable<TElement>
        where TElement : IItem
    {
        string Id { get; set; }
        string Name { get; set; }
        string Title { get; set; }
        string Language { get; set; }
        DateTime LastUpdatedTime { get; set; }

        string AddFeed(IItem element);
        IEnumerable<TElement> GetFeeds();
        
        TElement GetFeed(string id);
    }
}
