using System;
using System.ServiceModel.Syndication;
using TestTask.SDK;

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

        static void PrintAllFeeds()
        {
            IFeedProvider<IItem> provider = ProvidersFactory.GetProvider(ProviderType.Rss);
            IFeed<IItem> collection = provider.GetFeedCollection(URL);

            foreach (IItem one in collection)
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
            IFeed<RSSAtomItem> collection = provider.GetFeedCollection(URL);

            Console.WriteLine(collection.AddFeed(new RSSAtomItem("new feed", "description", "text", "someurl", "title", new DateTime())));
        }
    }

}
