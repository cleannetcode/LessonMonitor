using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
	public class GithubAccountConfiguration : IEntityTypeConfiguration<GitHubAccount>
	{
		public void Configure(EntityTypeBuilder<GitHubAccount> builder)
		{
			builder.HasKey(x => x.MemberId);

			builder.Property(x => x.Nickname).HasMaxLength(200);
			builder.Property(x => x.Link).HasMaxLength(1000);

			builder.HasOne(x => x.Member)
				.WithOne(x => x.GitHubAccount)
				.OnDelete(DeleteBehavior.NoAction)
				.HasPrincipalKey<Member>(x => x.Id)
				.HasForeignKey<GitHubAccount>(x => x.MemberId)
				.IsRequired();
		}
	}
}
