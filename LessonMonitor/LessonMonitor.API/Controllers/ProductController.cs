using LessonMonitor.Core;
using LessonMonitor.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LessonMonitor.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IProductDetailsService productDetailsService;

        public ProductController(IProductService productService, IProductDetailsService productDetailsService)
        {
            this.productService = productService;
            this.productDetailsService = productDetailsService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        {
            return productService.GetProducts();
        }
    }
}
