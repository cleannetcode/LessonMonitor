using LessonMonitor.Core.Models;

namespace LessonMonitor.Core
{
    public interface IProductDetailsService
    {
        ProductDetails GetProductDetail(int id);
    }
}
