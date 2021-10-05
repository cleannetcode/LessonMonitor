using LessonMonitor.Core;
using LessonMonitor.DataAccess;
using System.Collections.Generic;

namespace LessonMonitor.BusinessLogic
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        private IRepository<ProductDetails> productDetailsRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductDetails> productDetailRepository)
        {
            this.productRepository = productRepository;
            this.productDetailsRepository = productDetailRepository;
        }
        public IEnumerable<Product> GetProduct()
        {
            return productRepository.GetAll();
        }

        public Product GetProduct(int id)
        {
            return productRepository.Get(id);
        }
    }
}
