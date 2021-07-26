using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using LessonMonitor.DataAccess.MSSQL.Entities;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class TimecodeConfiguration : IEntityTypeConfiguration<Timecode>
    {
        public void Configure(EntityTypeBuilder<Timecode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Text).HasMaxLength(1000);
        }
    }
}
