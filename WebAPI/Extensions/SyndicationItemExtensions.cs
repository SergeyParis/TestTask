using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Linq;
//delete empty line
using TestTask.SDK.Models;

//fix namesapce
namespace TestTask.SDK
{
    public static class SyndicationItemCollectionExtensions
    {
        //rename to ToRssAtomList
        public static List<RSSAtomItem> ToRSSAtomList(this IEnumerable<SyndicationItem> enumerable)
        {//check for null
            List<RSSAtomItem> feeds = new List<RSSAtomItem>();

            //convert to LINQ select
            foreach (SyndicationItem one in enumerable)
                feeds.Add(new RSSAtomItem(one.Id, one.Summary.Text, one.Summary.Type, 
                    /*remove to string. What happens when there will be no Links? It will raise an exception*/ 
                    one.Links.First().Uri.OriginalString.ToString(), 
                    one.Title.Text, one.PublishDate.DateTime));

            return feeds;
        }
        public static RSSAtomFeed ToRSSAtomFeedCollection(this SyndicationFeed feed, string id) => 
            //check input paramters
            new RSSAtomFeed(id, feed);
    }
}
