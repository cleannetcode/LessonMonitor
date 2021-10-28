namespace LessonMonitor.API.Models
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public int StockAvailable { get; set; }
        public decimal Price { get; set; }
        public Product Product { get; set; }
    }
}