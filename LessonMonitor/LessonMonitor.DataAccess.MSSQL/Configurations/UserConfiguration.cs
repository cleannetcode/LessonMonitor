using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Member)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey<Member>(x => x.Id)
                .HasForeignKey<User>(x => x.Id)
                .IsRequired();
        }
    }
}
