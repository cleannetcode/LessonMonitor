using LessonMonitor.Core.Models;
using System.Collections.Generic;

namespace LessonMonitor.Core
{
    public interface IProductService
    {
        IEnumerable<Product> GetProduct();
        Product GetProduct(int id);
    }
}
