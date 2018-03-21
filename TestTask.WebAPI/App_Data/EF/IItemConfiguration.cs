using System.Data.Entity.ModelConfiguration;
using TestTask.SDK.Models;
//namespace
namespace TestTask.WebAPI
{
    //Change name to ItemConfiguration
    internal class IItemConfiguration : EntityTypeConfiguration<IItem>
    {
        public IItemConfiguration()
        {
            //Nice
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