namespace LessonMonitor.DataAccess
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public virtual ProductDetails Details { get; set; }
    }
}
