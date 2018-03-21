using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestTask.SDK.Models;
using TestTask.SDK.Providers;

namespace TestTask.Tests.SDK.Providers
{
    [TestClass]
    public class RSSAtomProviderTest//Tests
    {
        //use interface, not classes
        private MessageLogger logger;//private ILogger _logger
        private RSSAtomProvider provider; //the same

        [TestInitialize]
        public void Initialize()
        {
            logger = new MessageLogger();
            provider = (RSSAtomProvider)ProvidersFactory.GetProvider(ProviderType.RSS, logger: logger);
        }

        //Change name to RssAtomProvider_GetFeedCollection_should_set_logger_message
        //and all other test names as well
        //Use Arrange, Act, Assert comments in every test
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
            IFeed<RSSAtomItem> c = provider.GetFeedCollection(@"https://ru.stackoverflow.com/feeds");

            Assert.IsNotNull(c.Title);
        }
    }
}
