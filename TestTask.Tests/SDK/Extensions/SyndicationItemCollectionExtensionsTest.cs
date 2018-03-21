using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ServiceModel.Syndication;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TestTask.SDK;
using TestTask.SDK.Models;
//namespace + usings
namespace TestTask.Tests.SDK
{
    [TestClass]
    public class SyndicationItemCollectionExtensionsTest
    {
        [TestMethod]
        public void ToRSSAtomListTest_2EqualCollection()
        {
            DateTimeOffset offset = DateTimeOffset.MinValue;
            IEnumerable<SyndicationItem> enumerable = GenerateEnumerable(); //extract into a separate method, or place implementation on the top
            
            List<RSSAtomItem> expected = new List<RSSAtomItem>()
                {
                    new RSSAtomItem($"id0", "0", "text", $"https://stackoverflow0.com", $"title0", offset.DateTime ),
                    new RSSAtomItem($"id1", "1", "text", $"https://stackoverflow1.com", $"title1", offset.DateTime )
                };
            
            foreach (RSSAtomItem one in enumerable.ToRSSAtomList())
                if (!expected.Contains(one))
                    Assert.Fail();
            
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
}
