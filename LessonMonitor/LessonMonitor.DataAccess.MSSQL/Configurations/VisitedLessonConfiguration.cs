using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class VisitedLessonConfiguration : IEntityTypeConfiguration<VisitedLesson>
    {
        public void Configure(EntityTypeBuilder<VisitedLesson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Questions)
                .WithOne(x => x.VisitedLesson)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.VisitedLessonId)
                .IsRequired();

            builder.HasMany(x => x.Timecodes)
                .WithOne(x => x.VisitedLesson)
                .OnDelete(DeleteBehavior.NoAction)
                .HasForeignKey(x => x.VisitedLessonId)
                .IsRequired();
        }
    }
}
