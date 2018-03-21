using System;
using System.Xml;
using System.ServiceModel.Syndication;

using TestTask.SDK.Models;

namespace TestTask.SDK.Providers
{
    public class RSSAtomProvider : IFeedProvider<RSSAtomItem>
    {
        private readonly ICacher _cacher;
        internal static ILogger _logger;//it should not be static, you will have concurrency issues in this case

        public long CacheStorageTimeMiliseconds { get; set; } = 1000 * 60 * 60;  // 1 hour

        internal static ILogger Logger
        {
            get => _logger;
            set
            {
                _logger = value;
                RSSAtomFeed.Logger = value;
                RSSAtomItem.Logger = value;
            }
        }

        public bool Cacheable { get; set; }
        //it is not used
        internal RSSAtomProvider(ICacher cacher = null) : this()
        {
            if (cacher != null)
                Cacheable = true;

            _cacher = cacher;
        }
        public RSSAtomProvider() { }

        public IFeed<RSSAtomItem> GetFeedCollection(string url)
        {
            //you should also throw exceptions if paramter is incorrect
            if (url == null)
                Logger?.Log(nameof(RSSAtomProvider), nameof(GetFeedCollection), new ArgumentException($"{url} must be not-null"));
            else if (string.IsNullOrEmpty(url))
                Logger?.Log(nameof(RSSAtomProvider), nameof(GetFeedCollection), new ArgumentException($"{url} must be not empty string"));
            else //should you remove this else and return Load(url) in every case?
                return Load(url);

            return new RSSAtomFeed("empty", new SyndicationFeed());
        }

        private RSSAtomFeed Load(string url)
        {//check url for null/empty string/ whitespace
            string id = GetUniqId(url);

            if (!Cacheable) // what will happen if it is Cacheble but there is not data in the cache yet?
                return LoadFromWeb(url).ToRSSAtomFeedCollection(id);

            //what's the point of if? In both cases you load data from cache
            if (_cacher.GetTimeExistCacheMiliseconds(id) < CacheStorageTimeMiliseconds)
                //extract the whole if to a separate method GetFromCache
            {
                RSSAtomFeed c = _cacher.GetCollection(id) as RSSAtomFeed;

                if (c == null)
                    Logger?.Log(nameof(RSSAtomProvider), nameof(Load), new NullReferenceException($"{nameof(c)} must be not-null"));

                return c;
            }
            else
                //extract into a separate method, is it 'UpdateCache'?
            {
                RSSAtomFeed c = _cacher.GetCollection(id) as RSSAtomFeed;

                if (c == null)
                    //you should throw exception herer
                    Logger?.Log(nameof(RSSAtomProvider), nameof(Load), new NullReferenceException($"{nameof(c)} cannot be null"));
                else
                    _cacher.CachingCollection(c);

                return c;
            }
        }

        //extract it into FeedReader class with it own interface IFeedReader and call that, instead of this method
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

        //move these 2 methods to StringExtensions class
        protected virtual string GetUniqId(string url) => GenerateUniqId(url);

        public static string GenerateUniqId(string url) => url.Replace('/', '_').
                                                Replace("http:__", "").Replace("https:__", "").
                                                Replace(".xml", "").Replace("www.", "");
    }
}