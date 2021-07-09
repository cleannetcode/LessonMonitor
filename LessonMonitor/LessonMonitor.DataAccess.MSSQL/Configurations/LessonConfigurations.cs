using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class LessonConfigurations : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Title).HasMaxLength(500);
            builder.Property(x => x.Description).HasMaxLength(2000);

            builder.HasMany(x => x.Homeworks)
                .WithOne(x => x.Lesson)
                .OnDelete(DeleteBehavior.NoAction)
                .IsRequired();
        }
    }
}
