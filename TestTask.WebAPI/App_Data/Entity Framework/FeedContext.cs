using System.Data.Entity;

namespace TestTask.SDK.Models
{
    internal class FeedContext : DbContext
    {
        public FeedContext() : base("FeedConnection")
        {

        }

        public DbSet<IFeed> Feeds { get; set; }
        public DbSet<IFeedCollection<IFeed>> FeedCollections { get; set; }

    }
}
