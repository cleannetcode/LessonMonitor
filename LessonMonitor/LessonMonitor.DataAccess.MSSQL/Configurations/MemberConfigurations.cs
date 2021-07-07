using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class MemberConfigurations : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(200);

            builder.HasOne(x => x.GitHubAccount)
                .WithOne(x => x.Member)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey<Member>(x => x.GitHubAccountId)
                .IsRequired(false);

        }
    }
}
