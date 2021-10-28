namespace LessonMonitor.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ProductDetails Details { get; set; }
    }
}
