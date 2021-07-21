using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
	public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
	{
		public void Configure(EntityTypeBuilder<Lesson> builder)
		{
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(2000);
            builder.Property(x => x.YouTubeBroadcastId).HasMaxLength(2000);

            builder.ToTable("Lessons");

            builder.HasOne(x => x.Homework)
                .WithOne(x => x.Lesson)
                .OnDelete(DeleteBehavior.NoAction)
                .HasPrincipalKey<Lesson>(x => x.Id)
                .HasForeignKey<Homework>(x => x.LessonId)
                .IsRequired(false);
        }
	}
}
