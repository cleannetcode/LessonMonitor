using System;
using System.Linq;
using System.Threading.Tasks;
using EFCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore
{
	internal class Program
	{
		private const string connectionString = "Server=localhost;Database=MyDb;Integrated Security=true;";

		private static async Task Main(string[] args)
		{
			var builder = new DbContextOptionsBuilder<MyDbContext>();
			builder.UseSqlServer(connectionString);

			var contextFactory = new MyDbContextFactory();

			await using (var context = contextFactory.CreateDbContext(args))
			{
				// Create new product
				{
					//var product = new Product
					//{
					//	//Id = 6,
					//	Name = "Wine",
					//};

					//var result = context.Products.Add(product);
					////context.Attach(product).State = EntityState.Added;
					//await context.SaveChangesAsync();

					//Console.WriteLine(product.Id);
					//Console.WriteLine(result.Entity.Id);
				}

				// Get list of products
				{
					//var products = await context.Products
					//	.ToArrayAsync();

					//foreach (var product in products)
					//{
					//	Console.WriteLine($"{product.Id}, {product.Name}");
					//}
				}

				// Update product by Id
				{
					//var productToUpdate = await context.Products
					//	.FirstOrDefaultAsync(x => x.Id == 2);

					//productToUpdate.Name = "Meat1";

					//await context.SaveChangesAsync();
				}

				// Update product by Id
				{
					//var product = new Product
					//{
					//	//Id = 6,
					//	Name = "Wine"
					//};

					//context.Products.Update(product);
					//await context.SaveChangesAsync();

				}

				// Update product by Id
				{
					//var product = new Product
					//{
					//	//Id = 6,
					//	Name = "Wine"
					//};

					//context.Attach(product).State = EntityState.Modified;
					//await context.SaveChangesAsync();
				}

				{ // get with map
				  //var product = await GetProduct(context, 2);
				  //product.Name = "Wine";
				}

				{ // update
				  //var productToUpdate = new Product
				  //{
				  //	Id = 6,
				  //	Name = "Meat"
				  //};

					//await UpdateProduct(context, productToUpdate);
				}

				{ // where
				  //var productsQuery = context.Products
				  //	.Where(x => x.Id > 3);

					//var product = await productsQuery
					//	.Where(x => x.Id > 14)
					//	.FirstOrDefaultAsync();
				}

				{
					//context.Categories.Remove(new Category { Id = 1 });
					//await context.SaveChangesAsync();
				}

				{
					//var products = await context
					//	.Products
					//	.AsNoTracking()
					//	.Include(x => x.Category)
					//	.ToArrayAsync();


					//var products = await context
					//	.Products
					//	.AsNoTracking()
					//	.Join(context.Categories,
					//		product => product.CategoryId,
					//		category => category.Id,
					//		(product, category) => new Product
					//		{
					//			Id = product.Id,
					//			Name = product.Name,
					//			CategoryId = product.CategoryId,
					//			Category = new Category
					//			{
					//				Name = category.Name
					//			}
					//		})
					//	.ToArrayAsync();

					//var products = await context.Products
					//	.Where(x => x.Category.Name == "Food")
					//	.ToArrayAsync();
				}
			}
		}

		private static async Task<Product> GetProduct(MyDbContext context, int productId)
		{
			var product = await context.Products
				.AsNoTracking()
				.SingleOrDefaultAsync(x => x.Id == productId);

			return product;
		}

		private static async Task UpdateProduct(MyDbContext context, Product product)
		{
			context.Products.Update(product);
			await context.SaveChangesAsync();
		}
	}
}
