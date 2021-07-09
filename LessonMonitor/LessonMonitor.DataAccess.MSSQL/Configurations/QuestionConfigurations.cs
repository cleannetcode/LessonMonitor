using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;

namespace LessonMonitor.DataAccess.MSSQL.Configurations
{
    public class QuestionConfigurations : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Description).HasMaxLength(2000);

            builder.HasOne(x => x.Member)
               .WithMany(x => x.Questions)
               .OnDelete(DeleteBehavior.NoAction)
               .IsRequired();
        }
    }
}
