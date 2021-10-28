namespace LessonMonitor.DataAccess
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public ProductDetails Details { get; set; }
    }
}
