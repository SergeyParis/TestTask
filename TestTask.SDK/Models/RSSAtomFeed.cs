using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace TestTask.SDK
{
    public sealed class RSSAtomFeed : IFeed<RSSAtomItem>
    {
        private string _id;
        private string _name;
        private string _title;
        private string _language;
        private DateTime _lastUpdatedTime;
        private List<RSSAtomItem> _feeds;
        private List<RSSAtomItem> Feeds
        {
            set { _feeds = value; }
            get => _feeds ?? new List<RSSAtomItem>();
        }

        internal static ILogger Logger { get; set; }

        public string Id {
            get => _id;
            set
            {
                if (value == null)
                    _id = "";
                else
                    _id = value;
            }
        }
        public string Name
        {
            get => _name;
            set
            {
                if (value == null)
                    _name = "";
                else
                    _name = value;
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                if (value == null)
                    _title = "";
                else
                    _title = value;
            }
        }
        public string Language
        {
            get => _id;
            set
            {
                if (value == null)
                    _language = "";
                else
                    _language = value;
            }
        }
        public DateTime LastUpdatedTime
        {
            get => _lastUpdatedTime;
            set
            {
                if (value == null)
                    _lastUpdatedTime = DateTime.MinValue;
                else
                    _lastUpdatedTime = value;
            }
        }
        public int Count => Feeds.Count;

        public RSSAtomFeed() : this("empty", "n", "t", "l", DateTime.MinValue, new RSSAtomItem[0]) { }
        public RSSAtomFeed(string id, SyndicationFeed syndicationFeed)
        {
            if (id == null || syndicationFeed == null)
            {
                Logger?.Log(nameof(RSSAtomFeed), nameof(RSSAtomFeed), new ArgumentNullException("Arguments must be not-null"));
                return;
            }

            Id = id;
            Name = syndicationFeed.Id ?? "";
            Title = syndicationFeed.Title?.Text ?? "";
            Language = syndicationFeed.Language ?? "";
            LastUpdatedTime = syndicationFeed.LastUpdatedTime.DateTime;
            _feeds = InitFeeds(syndicationFeed.Items);
        }
        public RSSAtomFeed(string id, string name, string title, string language, DateTime lastUpdatedTime, IEnumerable<RSSAtomItem> items)
        {
            if (string.IsNullOrEmpty(id) ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(title) ||
                string.IsNullOrEmpty(language) ||
                lastUpdatedTime == null ||
                items == null)
            {
                Logger?.Log(nameof(RSSAtomFeed), nameof(RSSAtomFeed), new ArgumentException($"arguments must be not-null"));
                return;
            }

            Id = id;
            Name = name;
            Title = title;
            Language = language;
            LastUpdatedTime = lastUpdatedTime;
            _feeds = items.ToList();
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

        private static List<RSSAtomItem> InitFeeds(IEnumerable<SyndicationItem> enumerable)
        {
            if (enumerable == null)
            {
                Logger?.Log(nameof(RSSAtomFeed), nameof(AddFeed), new ArgumentNullException($"{nameof(enumerable)} must be not-null"));
                return new List<RSSAtomItem>();
            }

            return enumerable.ToRssAtomList();
        }
    }
}
