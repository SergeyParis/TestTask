using System;
using System.Xml;
using System.ServiceModel.Syndication;

using TestTask.SDK.Models;

namespace TestTask.SDK.Providers
{
    public class RSSAtomProvider : IFeedCollectionProvider<RSSAtomFeed>
    {
        private readonly ICacher _cacher;
        internal static ILogger _logger;

        public long CacheStorageTimeMiliseconds { get; set; } = 1000 * 60 * 60;  // 1 hour

        internal static ILogger Logger
        {
            get => _logger;
            set
            {
                _logger = value;
                RSSAtomFeedCollection.Logger = value;
                RSSAtomFeed.Logger = value;
            }
        }

        public bool Cacheable { get; set; }

        internal RSSAtomProvider(ICacher cacher = null) : this()
        {
            if (cacher != null)
                Cacheable = true;

            _cacher = cacher;
        }
        public RSSAtomProvider() { }

        public IFeedCollection<RSSAtomFeed> GetFeedCollection(string url)
        {
            if (url == null)
                Logger?.Log(nameof(RSSAtomProvider), nameof(GetFeedCollection), new ArgumentException($"{url} must be not-null"));
            else if (string.IsNullOrEmpty(url))
                Logger?.Log(nameof(RSSAtomProvider), nameof(GetFeedCollection), new ArgumentException($"{url} must be not empty string"));
            else
                return Load(url);

            return new RSSAtomFeedCollection("empty", new SyndicationFeed());
        }

        private RSSAtomFeedCollection Load(string url)
        {
            string id = GetUniqId(url);

            if (!Cacheable)
                return LoadFromWeb(url).ToRSSAtomFeedCollection(id);

            if (_cacher.GetTimeExistCacheMiliseconds(id) < CacheStorageTimeMiliseconds)
            {
                RSSAtomFeedCollection c = _cacher.GetCollection(id) as RSSAtomFeedCollection;

                if (c == null)
                    Logger?.Log(nameof(RSSAtomProvider), nameof(Load), new NullReferenceException($"{nameof(c)} must be not-null"));

                return c;
            }
            else
            {
                RSSAtomFeedCollection c = _cacher.GetCollection(id) as RSSAtomFeedCollection;

                if (c == null)
                    Logger?.Log(nameof(RSSAtomProvider), nameof(Load), new NullReferenceException($"{nameof(c)} cannot be null"));
                else
                    _cacher.CachingCollection(c);

                return c;
            }
        }

        private SyndicationFeed LoadFromWeb(string url)
        {
            SyndicationFeed channel;

            try
            {
                using (XmlReader feedReader = XmlReader.Create(url, new XmlReaderSettings { DtdProcessing = DtdProcessing.Parse, MaxCharactersFromEntities = 1024 }))
                {
                    channel = SyndicationFeed.Load(feedReader);
                }
            }
            catch (Exception e)
            {
                Logger.Log(nameof(RSSAtomProvider), nameof(LoadFromWeb), e);
                return null;
            }

            return channel;
        }
        protected virtual string GetUniqId(string url) => url.Replace('/', '_').
                                                Replace("http:__", "").Replace("https:__", "").
                                                Replace(".xml", "").Replace("www.", "");
    }
}