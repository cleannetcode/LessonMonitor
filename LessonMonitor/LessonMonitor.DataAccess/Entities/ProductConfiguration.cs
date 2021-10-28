using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.HasOne(p => p.Details).WithOne(p => p.Product).
                HasForeignKey<ProductDetails>(x => x.Id);
        }
    }
}
