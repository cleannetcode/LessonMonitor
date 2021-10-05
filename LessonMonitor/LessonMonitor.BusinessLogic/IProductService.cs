using LessonMonitor.DataAccess;
using System.Collections.Generic;

namespace LessonMonitor.BusinessLogic
{
    public interface IProductService
    {
        IEnumerable<Product> GetProduct();
        Product GetProduct(int id);
    }
}
