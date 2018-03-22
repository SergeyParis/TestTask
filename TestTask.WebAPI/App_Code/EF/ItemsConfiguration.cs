using System.Data.Entity.ModelConfiguration;
using TestTask.SDK.Models;

namespace TestTask.WebAPI
{
    internal class ItemsConfiguration : EntityTypeConfiguration<IItem>
    {
        public ItemsConfiguration()
        {
            Map(it => it.ToTable("Items"));
            HasKey(it => it.Id);

            Property(it => it.TypeDescription).IsOptional();
            Property(it => it.Description).IsOptional();
            Property(it => it.Link).IsRequired() ;
            Property(it => it.PublishDate).IsRequired().HasColumnType("datetime2");
            Property(it => it.Title).IsRequired();
        }
    }
}