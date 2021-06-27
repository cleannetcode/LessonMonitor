using EFCore.Configurations;
using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new ProductConfigurations());
			modelBuilder.ApplyConfiguration(new CategoryConfigurations());

			base.OnModelCreating(modelBuilder);
		}
	}
}
