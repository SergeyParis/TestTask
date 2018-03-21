using System;
using System.ServiceModel.Syndication;
using System.Collections.Generic;

using TestTask.SDK;
using TestTask.SDK.Providers;
using TestTask.SDK.Models;

namespace TestTask.ConsoleTest
{
    class Program
    {
        private const string URL = @"https://blogs.msdn.microsoft.com/dotnet/feed/";

        static void Main(string[] args)
        {
            PrintAllFeeds();
            WriteFeed();
            
            Console.ReadKey();
        }
        
        internal sealed class MessageLogger : ILogger
        {
            public string Message { get; set; }
            public void Log(string className, string methodName, Exception exception) => Message = exception.Message;
        }

        static void PrintAllFeeds()
        {
            IFeedCollectionProvider<IFeed> provider = ProvidersFactory.GetProvider(ProviderType.RSS);
            IFeedCollection<IFeed> collection = provider.GetFeedCollection(URL);

            foreach (IFeed one in collection)
                Console.WriteLine($"Id: {one.Id}\n" +
                                  $"Link: {one.Link}\n" +
                                  $"PublishDate: {one.PublishDate}\n" +
                                  $"Title: {one.Title}\n" +
                                  $"TypeDescription: {one.TypeDescription}\n" +
                                  $"Description: {one.Description}\n\n\n");
        }
        static void WriteFeed()
        {
            RSSAtomProvider provider = new RSSAtomProvider();
            IFeedCollection<RSSAtomFeed> collection = provider.GetFeedCollection(URL);

            Console.WriteLine(collection.AddFeed(new RSSAtomFeed("new feed", "description", "text", "someurl", "title", new DateTime())));
        }
    }

}
