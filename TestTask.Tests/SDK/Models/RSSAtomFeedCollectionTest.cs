using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel.Syndication;

using TestTask.SDK.Models;
using TestTask.SDK.Providers;

namespace TestTask.Tests.SDK
{
    [TestClass]
    public class RSSAtomFeedCollectionTest
    {
        private MessageLogger logger;

        [TestInitialize]
        public void Initialize()
        {
            logger = new MessageLogger();
            ProvidersFactory.GetProvider(ProviderType.RSS, logger: logger);
        }

        [TestMethod]
        public void RSSAtomFeedCollectionTest_argumentNull_log()
        {
            new RSSAtomFeedCollection(null, new System.ServiceModel.Syndication.SyndicationFeed());

            StringAssert.Contains(logger.Message, "must be not-null");
        }

        [TestMethod]
        public void AddFeedTest_argumentNull_log()
        {
            RSSAtomFeedCollection c = new RSSAtomFeedCollection("uniqId", new System.ServiceModel.Syndication.SyndicationFeed());

            c.AddFeed(null);

            StringAssert.Contains(logger.Message, $"must be not-null");
        }

        [TestMethod]
        public void AddFeedTest_validArg_2EqualObj()
        {
            RSSAtomFeedCollection c = new RSSAtomFeedCollection("uniqIdCollection", new SyndicationFeed());
            RSSAtomFeed expectedValue = new RSSAtomFeed("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue);

            c.AddFeed(new RSSAtomFeed("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue));

            Assert.AreEqual(expectedValue, c[c.Count - 1]);
        }

        [TestMethod]
        public void GetFeed_nullStr_log()
        {
            RSSAtomFeedCollection c = new RSSAtomFeedCollection("uniqIdCollection", new SyndicationFeed());
            c.AddFeed(new RSSAtomFeed("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue));
            
            RSSAtomFeed result = c.GetFeed(null);

            StringAssert.Contains(logger.Message, $"must be not-null");
        }

        [TestMethod]
        public void GetFeed_emptyStr_log()
        {
            RSSAtomFeedCollection c = new RSSAtomFeedCollection("uniqIdCollection", new SyndicationFeed());
            c.AddFeed(new RSSAtomFeed("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue));
            
            RSSAtomFeed result = c.GetFeed("");

            StringAssert.Contains(logger.Message, $"must be not empty string");
        }

        [TestMethod]
        public void GetFeed_valigStr_2EqualObj()
        {
            RSSAtomFeedCollection c = new RSSAtomFeedCollection("uniqIdCollection", new SyndicationFeed());
            c.AddFeed(new RSSAtomFeed("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue));

            RSSAtomFeed expectedValue = new RSSAtomFeed("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue);

            RSSAtomFeed result = c.GetFeed("uniqIdFeed");

            Assert.AreEqual(expectedValue, result);
        }
    }
}
