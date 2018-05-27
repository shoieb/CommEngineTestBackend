using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommEngineTestBackend.Model;
using CommEngineTestBackend.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommEngineTestBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
        {
            _productService = productService;
        }
        [HttpGet]
        public IEnumerable<Product> GetAll()
        {
            var allProduct = _productService.GetAll();
            return allProduct;
        }
        [HttpGet("{id}")]
        public Product GetById(Guid id)
        {
            var product = _productService.Find(id);
            return product;
        }

        [HttpPost]
        public IActionResult InsertOrUpdate([FromBody]Product product)
        {
            _productService.Save(product);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _productService.Delete(id);
            return Ok(id);
        }
    }
}