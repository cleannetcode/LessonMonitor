using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using System.Collections.Generic;

namespace LessonMonitor.BusinessLogic
{
    public class ProductService : IProductService
    {
        private IRepository<Product> productRepository;
        private IRepository<ProductDetails> productDetailsRepository;

        public ProductService(IRepository<Product> productRepository, IRepository<ProductDetails> productDetailsRepository)
        {
            this.productRepository = productRepository;
            this.productDetailsRepository = productDetailsRepository;
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
