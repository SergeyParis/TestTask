using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Linq;

namespace TestTask.SDK
{
    public static class SyndicationItemCollectionExtensions
    {
        public static List<RSSAtomItem> ToRssAtomList(this IEnumerable<SyndicationItem> enumerable)
        {
            if (enumerable == null)
                return null;

            List<RSSAtomItem> feeds = new List<RSSAtomItem>();

            foreach (SyndicationItem one in enumerable)
                feeds.Add(new RSSAtomItem(one.Id, one.Summary.Text, one.Summary.Type, one.Links.First().Uri.OriginalString, one.Title.Text, one.PublishDate.DateTime));

            return feeds;
        }
        public static RSSAtomFeed ToRSSAtomFeedCollection(this SyndicationFeed feed, string id)
        {
            if (id == null || feed == null || string.IsNullOrEmpty(id))
                return null;

            return new RSSAtomFeed(id, feed);
        }
    }
}
