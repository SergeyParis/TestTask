using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.SDK.Models
{
    public interface IFeedCollection<TElement> : IFeedCollection, IEnumerable<TElement>
        where TElement : IFeed
    {
        new string Id { get; }
        new object Title { get; }
        new string Language { get; }
        new DateTimeOffset LastUpdatedTime { get; }

        new IEnumerable<TElement> GetFeeds();

        string AddFeed(TElement feed);
        new TElement GetFeed(string id);
    }
}
