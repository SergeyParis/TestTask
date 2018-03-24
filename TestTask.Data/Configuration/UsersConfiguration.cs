using System.Data.Entity.ModelConfiguration;

namespace TestTask.Data
{
    internal class UsersConfiguration : EntityTypeConfiguration<UserWrapped>
    {
        public UsersConfiguration()
        {
            Map(it => it.ToTable("Users"));
            HasKey(it => it.Id);

            Property(it => it.Id).IsRequired();
            Property(it => it.Password).IsRequired();
        }
    } 
}