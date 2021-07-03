using System;
using LessonMonitor.DataAccess.Configurations;
using LessonMonitor.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LessonMonitor.DataAccess
{
    public partial class LessonMonitorDbContext : DbContext
    {
        public LessonMonitorDbContext()
        {
        }

        public LessonMonitorDbContext(DbContextOptions<LessonMonitorDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Achievement> Achievements { get; set; }
        public virtual DbSet<GetVisitedLesson> GetVisitedLessons { get; set; }
        public virtual DbSet<Homework> Homeworks { get; set; }
        public virtual DbSet<Lesson> Lessons { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Skill> Skills { get; set; }
        public virtual DbSet<Timecode> Timecodes { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UsersAchievement> UsersAchievements { get; set; }
        public virtual DbSet<UsersHomework> UsersHomeworks { get; set; }
        public virtual DbSet<UsersLesson> UsersLessons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=ASHTON\\ASHTON;Initial Catalog=LessonMonitorTestDb;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Achievement>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Rank)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<GetVisitedLesson>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("GetVisitedLessons");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Homework>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Homeworks)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_Homeworks_Topics");
            });

            modelBuilder.Entity<Lesson>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.Topic)
                    .WithMany(p => p.Lessons)
                    .HasForeignKey(d => d.TopicId)
                    .HasConstraintName("FK_Lessons_Topics");
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Vk).HasColumnName("VK");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Links_Users");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Questions_Users");
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Timecode>(entity =>
            {
                entity.Property(e => e.Description).HasMaxLength(600);

                entity.Property(e => e.Timecode1)
                    .HasColumnType("time(3)")
                    .HasColumnName("Timecode");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.Timecodes)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Timecodes_Lessons");
            });

            modelBuilder.Entity<Topic>(entity =>
            {
                entity.Property(e => e.Theme).HasMaxLength(200);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).HasMaxLength(200);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nicknames).HasMaxLength(100);
            });

            modelBuilder.Entity<UsersAchievement>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.AchievementId })
                    .HasName("PK_UserId_AchievementId");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Achievement)
                    .WithMany(p => p.UsersAchievements)
                    .HasForeignKey(d => d.AchievementId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersAchievements_Achievements");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersAchievements)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersAchievements_Users");
            });

            modelBuilder.Entity<UsersHomework>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.HomeworkId })
                    .HasName("PK_UserId_HomeworkId");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Homework)
                    .WithMany(p => p.UsersHomeworks)
                    .HasForeignKey(d => d.HomeworkId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersHomeworks_Homeworks");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersHomeworks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UsersHomeworks_Users");
            });

            modelBuilder.Entity<UsersLesson>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LessonId })
                    .HasName("PK_UserId_LessonId");

                entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Lesson)
                    .WithMany(p => p.UsersLessons)
                    .HasForeignKey(d => d.LessonId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitedLessons_Lessons");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersLessons)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_VisitedLessons_Users");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
