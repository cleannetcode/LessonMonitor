using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200);
            builder.Property(x => x.YouTubeUserId).HasMaxLength(200);

            builder.HasOne(x => x.GithubAccount)
                .WithOne(x => x.Member)
                .OnDelete(DeleteBehavior.NoAction);
            //.HasPrincipalKey<GithubAccount>(x => x.Id)
            //.HasForeignKey<Member>(x => x.GithubAccountId)
            //.IsRequired(false);

            // Member.GithubAccountId -> GithubAccount.Id
        }
    }
}
