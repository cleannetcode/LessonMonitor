using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class GithubAccountConfiguration : IEntityTypeConfiguration<GithubAccount>
    {
        public void Configure(EntityTypeBuilder<GithubAccount> builder)
        {
            builder.HasKey(x => x.MemberId);

            builder.Property(x => x.Nickname).HasMaxLength(200);
            builder.Property(x => x.Link).HasMaxLength(1000);

            builder.HasOne(x => x.Member)
                .WithOne(x => x.GithubAccount)
                .OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey<Member>(x => x.Id)
                .HasForeignKey<GithubAccount>(x => x.MemberId)
                .IsRequired();
        }
    }
}
