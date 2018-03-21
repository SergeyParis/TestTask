using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestTask.SDK;
using TestTask.SDK.Models;
using TestTask.SDK.Providers;

namespace TestTask.Tests.SDK
{
    [TestClass]
    public class RSSAtomFeedTest
    {
        [TestMethod]
        public void RSSAtomFeedTest_argumentNull_logDebug()
        {
            MessageLogger logger = new MessageLogger();
            ProvidersFactory.GetProvider(ProviderType.RSS, logger: logger);

            new RSSAtomItem(null, null, "text", @"https://stackoverflow.com", "title", DateTime.Now);

            StringAssert.Contains(logger.Message, "must be not-null");
        }
    }
}
