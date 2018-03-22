using System.Data.Entity.ModelConfiguration;

namespace TestTask.WebAPI
{
    internal class UsersConfiguration : EntityTypeConfiguration<IUser>
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