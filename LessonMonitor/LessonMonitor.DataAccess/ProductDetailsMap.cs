using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LessonMonitor.DataAccess
{
    public class ProductDetailsMap
    {
        public ProductDetailsMap(EntityTypeBuilder<ProductDetails> entityBuilder)
        {
            entityBuilder.HasKey(p => p.ProductId);
            entityBuilder.Property(p => p.StockAvailable).IsRequired();
            entityBuilder.Property(p => p.Price);
        }
    }
}
