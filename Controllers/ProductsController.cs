using KMStore.API.Models;
using KMStore.API.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace KMStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Product>> GetProducts()
        {
            var products = await _productRepository.GetProducts();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product == null) return NotFound("No Product match this Id.");

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product == null) return BadRequest();
            else
            {
                await _productRepository.AddProduct(product);

                return StatusCode(StatusCodes.Status201Created, "Product Successfully Added");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            var existingProduct = await _productRepository.GetProduct(id);

            if (existingProduct == null) return NotFound("No Product match this Id.");
            else
            {
                await _productRepository.UpdateProduct(id, product);
                return Ok("Product Successfully Updated");
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _productRepository.GetProduct(id);

            if (product == null) return BadRequest();
            else
            {
                await _productRepository.DeleteProduct(id);

                return Ok("Product Successfully Deleted");
            }
        }

    }
}
