using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Linq;

using TestTask.SDK.Models;

namespace TestTask.SDK
{
    public static class SyndicationItemCollectionExtensions
    {
        public static List<RSSAtomFeed> ToRSSAtomList(this IEnumerable<SyndicationItem> enumerable)
        {
            List<RSSAtomFeed> feeds = new List<RSSAtomFeed>();

            foreach (SyndicationItem one in enumerable)
                feeds.Add(new RSSAtomFeed(one.Id, one.Summary.Text, one.Summary.Type, one.Links.First().Uri.OriginalString.ToString(), one.Title.Text, one.PublishDate.DateTime));

            return feeds;
        }
        public static RSSAtomFeedCollection ToRSSAtomFeedCollection(this SyndicationFeed feed, string id) => new RSSAtomFeedCollection(id, feed);
    }
}
