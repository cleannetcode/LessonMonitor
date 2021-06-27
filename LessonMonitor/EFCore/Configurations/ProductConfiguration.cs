using EFCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore.Configurations
{
	public class ProductConfiguration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Name)
				.HasMaxLength(500)
				.IsRequired();

			var defaultCategoryId = 1;
			builder.Property(x => x.CategoryId)
				.HasDefaultValue(defaultCategoryId);
		}
	}
}
