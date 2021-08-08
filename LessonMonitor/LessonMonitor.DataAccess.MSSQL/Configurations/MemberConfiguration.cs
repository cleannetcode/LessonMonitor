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

            builder.HasOne(x => x.User)
                .WithOne(x => x.Member)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.VisitedLessons)
                .WithOne(x => x.Member)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.MemberId)
                .IsRequired();
        }
    }
}
