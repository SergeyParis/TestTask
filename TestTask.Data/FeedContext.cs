using System.Data.Entity;
using TestTask.SDK;

namespace TestTask.Data
{
    public class FeedContext : DbContext
    {
        static FeedContext()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FeedContext>());
        }
        public FeedContext() : base("FeedConnection")
        {
            
        }

        public DbSet<IUser> Users { get; set; }
        public DbSet<IItem> Items { get; set; }
        public DbSet<IFeed<IItem>> Feeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsersConfiguration());
            modelBuilder.Configurations.Add(new ItemsConfiguration());
            modelBuilder.Configurations.Add(new FeedsConfiguration());
        }

    }


}
