using LessonMonitor.DataAccess.MSSQL.Configurations;
using LessonMonitor.DataAccess.MSSQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace LessonMonitor.DataAccess.MSSQL
{
    public class LMonitorDbContext : DbContext
    {
        public LMonitorDbContext()
        {
        }

        public LMonitorDbContext(DbContextOptions<LMonitorDbContext> options)
            : base(options)
        {
        }

        public DbSet<Member> Members { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<GitHubAccount> GitHubAccounts { get; set; }
       // public DbSet<MemberHomework> MemberHomeworks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MemberConfigurations());
            modelBuilder.ApplyConfiguration(new QuestionConfigurations());
            modelBuilder.ApplyConfiguration(new HomeworkConfigurations());
            modelBuilder.ApplyConfiguration(new LessonConfigurations());
            modelBuilder.ApplyConfiguration(new GitHubAccountConfigurations());

            base.OnModelCreating(modelBuilder);
        }
    }
}
