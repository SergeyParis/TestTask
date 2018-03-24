using System.Data.Entity;

namespace TestTask.Data
{
    public class FeedContext : DbContext
    {
        static FeedContext()
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<FeedContext>());
        }
        public FeedContext() : base("FeedConnection")
        {
            
        }

        public DbSet<UserWrapped> Users { get; set; }
        public DbSet<ItemWrapped> Items { get; set; }
        public DbSet<FeedWrapped> Feeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Configurations.Add(new UsersConfiguration());
            modelBuilder.Configurations.Add(new ItemsConfiguration());
            modelBuilder.Configurations.Add(new FeedsConfiguration());
        }

    }
    
}
