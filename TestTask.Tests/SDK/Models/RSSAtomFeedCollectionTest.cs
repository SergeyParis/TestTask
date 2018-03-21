using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel.Syndication;
//remove line
using TestTask.SDK.Models;
using TestTask.SDK.Providers;
//namespace
namespace TestTask.Tests.SDK
{
    [TestClass]
    public class RSSAtomFeedCollectionTest
    {
        private MessageLogger logger; //change to interface, change name to _logger

        [TestInitialize]
        public void Initialize()
        {
            logger = new MessageLogger();
            ProvidersFactory.GetProvider(ProviderType.RSS, logger: logger); //remove
        }

        [TestMethod]
        public void RSSAtomFeedCollectionTest_argumentNull_log()
        {
            //remove System.ServiceModel.Syndication.
            new RSSAtomFeed(null, new System.ServiceModel.Syndication.SyndicationFeed());

            StringAssert.Contains(logger.Message, "must be not-null");
        }

        [TestMethod]
        public void AddFeedTest_argumentNull_log()
        {
            RSSAtomFeed c = new RSSAtomFeed("uniqId", new System.ServiceModel.Syndication.SyndicationFeed());

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
