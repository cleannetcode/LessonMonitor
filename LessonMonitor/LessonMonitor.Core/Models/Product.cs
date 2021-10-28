namespace LessonMonitor.Core.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public virtual ProductDetails Details { get; set; }
    }
}
