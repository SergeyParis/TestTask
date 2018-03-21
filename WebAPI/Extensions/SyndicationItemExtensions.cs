using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Linq;

using TestTask.SDK.Models;

namespace TestTask.SDK
{
    public static class SyndicationItemCollectionExtensions
    {
        public static List<RSSAtomItem> ToRSSAtomList(this IEnumerable<SyndicationItem> enumerable)
        {
            List<RSSAtomItem> feeds = new List<RSSAtomItem>();

            foreach (SyndicationItem one in enumerable)
                feeds.Add(new RSSAtomItem(one.Id, one.Summary.Text, one.Summary.Type, one.Links.First().Uri.OriginalString.ToString(), one.Title.Text, one.PublishDate.DateTime));

            return feeds;
        }
        public static RSSAtomFeed ToRSSAtomFeedCollection(this SyndicationFeed feed, string id) => new RSSAtomFeed(id, feed);
    }
}
