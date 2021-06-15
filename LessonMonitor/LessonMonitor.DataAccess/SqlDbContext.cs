using Microsoft.EntityFrameworkCore;

namespace LessonMonitor.DataAccess
{
    public class SqlDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }
       // public virtual DbSet<GitInfo> GitInform { get; set; }


        public SqlDbContext(DbContextOptions<SqlDbContext> options)
        : base(options)
        {

        }

        public SqlDbContext()
        {

        }
    }
}
