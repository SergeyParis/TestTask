using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace TestTask.SDK.Models
{
    public sealed class RSSAtomFeedCollection : SyndicationFeed, IFeedCollection<RSSAtomFeed>
    {
        internal static ILogger Logger { get; set; }
        private List<RSSAtomFeed> _feeds;

        private List<RSSAtomFeed> Feeds
        {
            set { _feeds = value; }
            get
            {
                if (_feeds == null)
                    _feeds = new List<RSSAtomFeed>();

                return _feeds;
            }
        }

        new public string Id { get; }
        public string Name { get; }
        public int Count => Feeds.Count;

        new public string Title => base.Title.Text;
        new public DateTime LastUpdatedTime => base.LastUpdatedTime.DateTime;

        public RSSAtomFeedCollection(string id, SyndicationFeed syndicationFeed)
            : base(syndicationFeed, false)
        {
            if (id == null || syndicationFeed == null)
                Logger?.Log(nameof(RSSAtomFeedCollection), nameof(RSSAtomFeedCollection), new ArgumentNullException("Arguments must be not-null"));

            Id = id;
            Name = syndicationFeed.Id;

            InitFeeds(syndicationFeed.Items);
        }

        public string AddFeed(IFeed feed)
        {
            if (feed == null)
            {
                Logger?.Log(nameof(RSSAtomFeedCollection), nameof(AddFeed), new ArgumentNullException($"{nameof(feed)} must be not-null"));

                return null;
            }

            this.Feeds.Add(new RSSAtomFeed(feed.Id, feed.Description, feed.TypeDescription, feed.Link, feed.Title, feed.PublishDate));
            return feed.Id;
        }
        public RSSAtomFeed GetFeed(string id)
        {
            if (id == null)
                Logger?.Log(nameof(RSSAtomFeedCollection), nameof(GetFeed), new ArgumentException($"{id} must be not-null"));              
            else if (string.IsNullOrEmpty(id))
                Logger?.Log(nameof(RSSAtomFeedCollection), nameof(GetFeed), new ArgumentException($"{id} must be not empty string"));
            else 
                return Feeds.First(feed => feed.Id == id);

            return Feeds.First();
        }
        public IEnumerable<RSSAtomFeed> GetFeeds() => Feeds;
        private void InitFeeds(IEnumerable<SyndicationItem> enumerable)
        {
            if (enumerable == null)
            {
                Logger?.Log(nameof(RSSAtomFeedCollection), nameof(AddFeed), new ArgumentNullException($"{nameof(enumerable)} must be not-null"));

                return;
            }

            this.Feeds = enumerable.ToRSSAtomList();
        }

        IEnumerator<RSSAtomFeed> IEnumerable<RSSAtomFeed>.GetEnumerator() => ((IEnumerable<RSSAtomFeed>)Feeds).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<RSSAtomFeed>)this).GetEnumerator();

        public override bool Equals(object obj)
        {
            if (obj is RSSAtomFeedCollection)
            {
                RSSAtomFeedCollection y = (RSSAtomFeedCollection)obj;

                foreach (RSSAtomFeed one in this)
                    if (!y.Contains(one))
                        return false;
            }

            return false;
        }
        public override int GetHashCode() => base.GetHashCode();

        public RSSAtomFeed this[int index]
        {
            get
            {
                if (index < 0)
                {
                    Logger?.Log(nameof(RSSAtomFeedCollection), "Indexator", new IndexOutOfRangeException("index must be >= 0"));
                    return this[0];
                }

                return Feeds[index];
            }
            set
            {
                if (index < 0)
                {
                    Logger?.Log(nameof(RSSAtomFeedCollection), "Indexator", new IndexOutOfRangeException("index must be >= 0"));
                    return;
                }

                Feeds[index] = value;
            }
        }
    }
}
