using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask.SDK;

namespace TestTask.Tests.SDK
{
    [TestClass]
    public class RSSAtomItemTest
    {
        [TestMethod]
        public void RSSAtomFeedTest_argumentNull_logDebug()
        {
            SimpleLogger logger = new SimpleLogger();
            ProvidersFactory.GetProvider(ProviderType.Rss, logger: logger);

            new RSSAtomItem(null, null, "text", @"https://stackoverflow.com", "title", DateTime.Now);

            StringAssert.Contains(logger.Message, "must be not-null");
        }
    }
}
