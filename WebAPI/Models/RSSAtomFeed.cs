using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace TestTask.SDK.Models
{
    public sealed class RSSAtomFeed : SyndicationFeed, IFeed<RSSAtomItem>
    {
        private List<RSSAtomItem> _feeds;
        private List<RSSAtomItem> Feeds
        {
            set { _feeds = value; }
            get => _feeds ?? new List<RSSAtomItem>();
        }

        internal static ILogger Logger { get; set; }

        new public string Id { get; }
        public string Name { get; }
        public int Count => Feeds.Count;
        new public string Title => base.Title.Text;
        new public DateTime LastUpdatedTime => base.LastUpdatedTime.DateTime;


        public RSSAtomFeed(string id, SyndicationFeed syndicationFeed)
            : base(syndicationFeed, false)
        {
            if (id == null || syndicationFeed == null)
                Logger?.Log(nameof(RSSAtomFeed), nameof(RSSAtomFeed), new ArgumentNullException("Arguments must be not-null"));

            Id = id;
            Name = syndicationFeed.Id;

            InitFeeds(syndicationFeed.Items);
        }

        public string AddFeed(IItem feed)
        {
            if (feed == null)
            {
                Logger?.Log(nameof(RSSAtomFeed), nameof(AddFeed), new ArgumentNullException($"{nameof(feed)} must be not-null"));

                return null;
            }

            this.Feeds.Add(new RSSAtomItem(feed.Id, feed.Description, feed.TypeDescription, feed.Link, feed.Title, feed.PublishDate));
            return feed.Id;
        }
        public RSSAtomItem GetFeed(string id)
        {
            if (id == null)
                Logger?.Log(nameof(RSSAtomFeed), nameof(GetFeed), new ArgumentException($"{id} must be not-null"));
            else if (string.IsNullOrEmpty(id))
                Logger?.Log(nameof(RSSAtomFeed), nameof(GetFeed), new ArgumentException($"{id} must be not empty string"));
            else
                return Feeds.First(feed => feed.Id == id);

            return Feeds.First();
        }
        public IEnumerable<RSSAtomItem> GetFeeds() => Feeds;

        public override bool Equals(object obj)
        {
            if (obj is RSSAtomFeed)
            {
                RSSAtomFeed y = (RSSAtomFeed)obj;

                foreach (RSSAtomItem one in this)
                    if (!y.Contains(one))
                        return false;
            }

            return false;
        }
        public override int GetHashCode() => base.GetHashCode();

        public RSSAtomItem this[int index]
        {
            get
            {
                if (index < 0)
                {
                    Logger?.Log(nameof(RSSAtomFeed), "Indexator", new IndexOutOfRangeException("index must be >= 0"));
                    return this[0];
                }

                return Feeds[index];
            }
            set
            {
                if (index < 0)
                {
                    Logger?.Log(nameof(RSSAtomFeed), "Indexator", new IndexOutOfRangeException("index must be >= 0"));
                    return;
                }

                Feeds[index] = value;
            }
        }

        IEnumerator<RSSAtomItem> IEnumerable<RSSAtomItem>.GetEnumerator() => ((IEnumerable<RSSAtomItem>)Feeds).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<RSSAtomItem>)this).GetEnumerator();

        private void InitFeeds(IEnumerable<SyndicationItem> enumerable)
        {
            if (enumerable == null)
            {
                Logger?.Log(nameof(RSSAtomFeed), nameof(AddFeed), new ArgumentNullException($"{nameof(enumerable)} must be not-null"));

                return;
            }

            this.Feeds = enumerable.ToRssAtomList();
        }
    }
}
