using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess
{
    public class ProductMap
    {
        public ProductMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(p => p.ProductId);
            entityBuilder.HasOne(p => p.ProductDetails).WithOne(p => p.Product).
                HasForeignKey<ProductDetails>(x => x.ProductId);
        }
    }
}
