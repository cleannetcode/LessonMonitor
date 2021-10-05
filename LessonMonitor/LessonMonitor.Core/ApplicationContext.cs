using LessonMonitor.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace LessonMonitor.Core
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            new ProductMap(modelBuilder.Entity<Product>());
            new ProductDetailsMap(modelBuilder.Entity<ProductDetails>());
        }
    }
}
