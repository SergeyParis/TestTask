using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestTask.SDK;

namespace TestTask.Tests.SDK
{
    [TestClass]
    public class SyndicationItemCollectionExtensionsTest
    {
        private DateTimeOffset offset;
        private IEnumerable<SyndicationItem> enumerable;

        [TestInitialize]
        public void Initialize()
        {
            offset = DateTimeOffset.MinValue;
            enumerable = GenerateEnumerable();
        }

        [TestMethod]
        public void ToRSSAtomListTest_2EqualCollection()
        {
            List<RSSAtomItem> expected = new List<RSSAtomItem>()
                {
                    new RSSAtomItem($"id0", "0", "text", $"https://stackoverflow0.com", $"title0", offset.DateTime ),
                    new RSSAtomItem($"id1", "1", "text", $"https://stackoverflow1.com", $"title1", offset.DateTime )
                };
            
            foreach (RSSAtomItem one in enumerable.ToRssAtomList())
                if (!expected.Contains(one))
                    Assert.Fail();
        }

        IEnumerable<SyndicationItem> GenerateEnumerable()
        {
            for (int i = 0; i < 2; i++)
            {
                SyndicationItem item = new SyndicationItem($"title{i}", $"content{i}",
                    new Uri($"https://stackoverflow{i}.com"), $"id{i}", offset);

                item.Summary = new TextSyndicationContent(i.ToString(), TextSyndicationContentKind.Plaintext);

                yield return item;
            }
        }
    }
}
