using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCore
{
	public class MyDbContextFactory : IDesignTimeDbContextFactory<MyDbContext>
	{
		private const string connectionString = "Server=localhost;Database=MyDb;Integrated Security=true;";

		public MyDbContext CreateDbContext(string[] args)
		{
			var builder = new DbContextOptionsBuilder<MyDbContext>();
			builder.UseSqlServer(connectionString);

			return new MyDbContext(builder.Options);
		}
	}
}
