namespace LessonMonitor.DataAccess
{
    public class ProductDetails : BaseEntity
    {
        public int StockAvailable { get; set; }
        public decimal Price { get; set; }
        public virtual Product Product { get; set; }
    }
}