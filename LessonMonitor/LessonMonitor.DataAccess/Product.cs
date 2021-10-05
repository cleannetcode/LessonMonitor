namespace LessonMonitor.DataAccess
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public virtual ProductDetails ProductDetails { get; set; }
    }
}
