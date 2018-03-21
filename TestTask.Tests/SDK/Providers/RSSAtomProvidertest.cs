using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestTask.SDK.Models;
using TestTask.SDK.Providers;

namespace TestTask.Tests.SDK.Providers
{
    [TestClass]
    public class RSSAtomProviderTest
    {
        private MessageLogger logger;
        private RSSAtomProvider provider;

        [TestInitialize]
        public void Initialize()
        {
            logger = new MessageLogger();
            provider = (RSSAtomProvider)ProvidersFactory.GetProvider(ProviderType.RSS, logger: logger);
        }

        [TestMethod]
        public void GetFeedCollectionTest_nullArg_log()
        {
            provider.GetFeedCollection(null);

            StringAssert.Contains(logger.Message, $"must be not-null");
        }

        [TestMethod]
        public void GetFeedCollectionTest_emptyArg_log()
        {
            provider.GetFeedCollection("");

            StringAssert.Contains(logger.Message, $"must be not empty string");
        }

        [TestMethod]
        public void GetFeedCollectionTest_validArg_log()
        {
            IFeedCollection<RSSAtomFeed> c = provider.GetFeedCollection(@"https://ru.stackoverflow.com/feeds");

            Assert.IsNotNull(c.Title);
        }
    }
}
