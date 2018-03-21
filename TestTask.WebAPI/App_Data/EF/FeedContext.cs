using System.Data.Entity;
using TestTask.SDK.Models;

//it should be placed here, as any other EF framework related class. Extract it into a separate project TestTask.Data
namespace TestTask.WebAPI
{
    internal class FeedContext : DbContext
    {
        public FeedContext() : base("FeedConnection") { }

        public DbSet<IItem> Feeds { get; set; }
        public DbSet<IFeed<IItem>> FeedCollections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new IItemConfiguration());
            modelBuilder.Configurations.Add(new IFeedConfiguration());
        }
    }
}
