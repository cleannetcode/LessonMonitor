namespace LessonMonitor.DataAccess
{
    public class ProductDetails : BaseEntity
    {
        public int StockAvailable { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
    }
}