using LessonMonitor.DataAccess;

namespace LessonMonitor.BusinessLogic
{
    public interface IProductDetailsService
    {
        ProductDetails GetProductDetail(int id);
    }
}
