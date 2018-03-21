using System.Data.Entity;
using TestTask.SDK.Models;

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

            modelBuilder.Entity<IFeed<IItem>>().Map(it => it.ToTable(""));
            modelBuilder.Entity<IFeed<IItem>>().HasKey(it => it.Id);
            
            modelBuilder.Entity<IFeed<IItem>>().Property(it => it.Name).IsRequired().HasMaxLength(30);
            modelBuilder.Entity<IFeed<IItem>>().Property(it => it.LastUpdatedTime).IsRequired().HasColumnType("datetime2");
            modelBuilder.Entity<IFeed<IItem>>().Property(it => it.Language).IsOptional().HasMaxLength(16);
            modelBuilder.Entity<IFeed<IItem>>().Property(it => it.Title).IsOptional().HasMaxLength(50);


            
        }
    }
}
