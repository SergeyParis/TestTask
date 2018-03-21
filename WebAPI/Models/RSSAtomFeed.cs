using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;

namespace TestTask.SDK.Models
{
    //refactor this class it is not readable
    //public properties
    //private properties
    //Constructor
    //public methods
    //private methods
    public sealed class RSSAtomFeed : SyndicationFeed, IFeed<RSSAtomItem>
    {
        //it should not be static
        internal static ILogger Logger { get; set; }
        private List<RSSAtomItem> _feeds;

        private List<RSSAtomItem> Feeds
        {
            set { _feeds = value; }
            get
            {
                //use ?? operator
                if (_feeds == null)
                    _feeds = new List<RSSAtomItem>();

                return _feeds;
            }
        }

        //why do you redeclare Id here?
        //every time new keyword is used - that a sign of a bad design
        new public string Id { get; }
        public string Name { get; }
        public int Count => Feeds.Count;

        //same here
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
            else if (string.IsNullOrEmpty(id)) //you already check for null above, check against string.empty and whitespace
                Logger?.Log(nameof(RSSAtomFeed), nameof(GetFeed), new ArgumentException($"{id} must be not empty string"));
            else 
                return Feeds.First(feed => feed.Id == id);

            //it should throw an exception if no entity is found
            return Feeds.First();
        }
        public IEnumerable<RSSAtomItem> GetFeeds() => Feeds;
        private void InitFeeds(IEnumerable<SyndicationItem> enumerable)
        {
            //use if else and delete {}
            if (enumerable == null)
            {
                Logger?.Log(nameof(RSSAtomFeed), nameof(AddFeed), new ArgumentNullException($"{nameof(enumerable)} must be not-null"));

                return;
            }
            //remove this
            this.Feeds = enumerable.ToRSSAtomList();
        }

        IEnumerator<RSSAtomItem> IEnumerable<RSSAtomItem>.GetEnumerator() => ((IEnumerable<RSSAtomItem>)Feeds).GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<RSSAtomItem>)this).GetEnumerator();

        public override bool Equals(object obj)
        {
            //reverse if to remove nesting
            if (obj is RSSAtomFeed)
            {
                RSSAtomFeed y = (RSSAtomFeed)obj;

                //use LINQ
                foreach (RSSAtomItem one in this)
                    if (!y.Contains(one))
                        return false;
            }

            return false;
        }
        //remove it, why do you need to override, if you call base class?
        public override int GetHashCode() => base.GetHashCode();

        public RSSAtomItem this[int index]
        {
            get
            {
                if (index < 0)
                {
                    
                    Logger?.Log(nameof(RSSAtomFeed), "Indexator", new IndexOutOfRangeException("index must be >= 0"));

                    return this[0];//remove it
                    //you should throw IndexOutOfRangeException exception here
                }

                return Feeds[index];
            }
            //it is never used remove it
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
    }
}
