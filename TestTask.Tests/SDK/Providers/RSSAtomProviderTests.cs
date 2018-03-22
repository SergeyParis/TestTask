using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask.SDK.Models;
using TestTask.SDK.Providers;

namespace TestTask.Tests.SDK.Providers
{
    [TestClass]
    public class RSSAtomProviderTests
    {
        private SimpleLogger logger;
        private IFeedProvider<IItem> provider;

        [TestInitialize]
        public void Initialize()
        {
            logger = new SimpleLogger();
            provider = (RSSAtomProvider)ProvidersFactory.GetProvider(ProviderType.RSS, logger: logger);
        }

        [TestMethod]
        public void RssAtomProvider_GetFeedCollection_should_set_logger_message_nullreference()
        {
            provider.GetFeedCollection(null);

            StringAssert.Contains(logger.Message, $"must be not-null");
        }

        [TestMethod]
        public void RssAtomProvider_GetFeedCollection_should_set_logger_message_emptystring()
        {
            provider.GetFeedCollection("");

            StringAssert.Contains(logger.Message, $"must be not empty string");
        }

        [TestMethod]
        public void RssAtomProvider_GetFeedCollection_should_not_be_null()
        {
            IFeed<IItem> c = provider.GetFeedCollection(@"https://ru.stackoverflow.com/feeds");

            Assert.IsNotNull(c.Title);
        }
    }
}
