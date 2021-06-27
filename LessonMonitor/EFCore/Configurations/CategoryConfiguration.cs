using EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<Category>
	{
		public void Configure(EntityTypeBuilder<Category> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.HasMaxLength(500)
				.IsRequired();

			builder
				.HasMany(x => x.Products)
				.WithOne(x => x.Category)
				.HasForeignKey(x => x.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

			builder.HasData(new Category
			{
				Id = 1,
				Name = "Food"
			});
		}
	}
}
