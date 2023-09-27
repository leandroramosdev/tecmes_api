using Microsoft.AspNetCore.Mvc;
using TecmesAPI.Models;
using TecmesAPI.Services.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TecmesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getAllProducts()
        {
            IEnumerable<Product> products = await _productService.getAllProducts();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProductById(int id)
        {
            Product product = await _productService.getProductById(id);
            return Ok(product);
        }

        [HttpGet("/api/Products/getByName")]
        public async Task<ActionResult<IEnumerable<Product>>> getProductsByName([FromQuery] string name)
        {
            IEnumerable<Product> products = await _productService.getProductsByName(name);

            if (products.Count() == 0)
            {
                return NotFound($"Não existem produtos com o nome {name}");
            }

            return Ok(products);
        }


        [HttpPost]
        public async Task<ActionResult<Product>> addProduct([FromBody] Product product)
        {
            Product result = await _productService.addProduct(product);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> updateProduct([FromBody] Product product, int id)
        {
            product.Id = id;
            Product result = await _productService.updateProduct(product, id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> deleteProduct(int id)
        {
            Boolean result = await _productService.deleteProduct(id);
            return Ok(result);
        }


    }
}

