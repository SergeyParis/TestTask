using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel.Syndication;
using TestTask.SDK.Models;
using TestTask.SDK.Providers;

namespace TestTask.Tests.SDK
{
    [TestClass]
    public class RSSAtomFeedTests
    {
        private SimpleLogger logger;

        [TestInitialize]
        public void Initialize()
        {
            logger = new SimpleLogger();
            ProvidersFactory.SetLogger(ProviderType.RSS, logger);
        }

        [TestMethod]
        public void RSSAtomFeedCollectionTest_argumentNull_log()
        {
            new RSSAtomFeed(null, new SyndicationFeed());

            StringAssert.Contains(logger.Message, "must be not-null");
        }

        [TestMethod]
        public void AddFeedTest_argumentNull_log()
        {
            RSSAtomFeed c = new RSSAtomFeed("uniqId", new SyndicationFeed());

            c.AddFeed(null);

            StringAssert.Contains(logger.Message, $"must be not-null");
        }

        [TestMethod]
        public void AddFeedTest_validArg_2EqualObj()
        {
            RSSAtomFeed c = new RSSAtomFeed("uniqIdCollection", new SyndicationFeed());
            RSSAtomItem expectedValue = new RSSAtomItem("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue);

            c.AddFeed(new RSSAtomItem("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue));

            Assert.AreEqual(expectedValue, c[c.Count - 1]);
        }

        [TestMethod]
        public void GetFeed_nullStr_log()
        {
            RSSAtomFeed c = new RSSAtomFeed("uniqIdCollection", new SyndicationFeed());
            c.AddFeed(new RSSAtomItem("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue));
            
            RSSAtomItem result = c.GetFeed(null);

            StringAssert.Contains(logger.Message, $"must be not-null");
        }

        [TestMethod]
        public void GetFeed_emptyStr_log()
        {
            RSSAtomFeed c = new RSSAtomFeed("uniqIdCollection", new SyndicationFeed());
            c.AddFeed(new RSSAtomItem("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue));
            
            RSSAtomItem result = c.GetFeed("");

            StringAssert.Contains(logger.Message, $"must be not empty string");
        }

        [TestMethod]
        public void GetFeed_valigStr_2EqualObj()
        {
            RSSAtomFeed c = new RSSAtomFeed("uniqIdCollection", new SyndicationFeed());
            c.AddFeed(new RSSAtomItem("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue));

            RSSAtomItem expectedValue = new RSSAtomItem("uniqIdFeed", "description", "text", "http:\\someurl.com", "title", DateTime.MinValue);

            RSSAtomItem result = c.GetFeed("uniqIdFeed");

            Assert.AreEqual(expectedValue, result);
        }
    }
}
