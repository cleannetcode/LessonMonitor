using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

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
