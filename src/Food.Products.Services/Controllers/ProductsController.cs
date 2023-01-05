using Food.Products.Services.Dtos;
using Food.Products.Services.Entities;
using Food.Products.Services.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Food.Products.Services.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductsController : ControllerBase
    {
       private readonly IRepository<Product> productsRepository;
       public ProductsController(IRepository<Product> productsRepository)
       {
        this.productsRepository =productsRepository;
       }
        [HttpGet]
        public async Task<IEnumerable<ProductDto>> GetAsync()
        {
            var products = (await productsRepository.GetAllAsync())
                            .Select(product => product.AsDto());
            return products;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetByIdAsync(Guid id)
        {
            var product = await productsRepository.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return product.AsDto();
        }
        [HttpPost]
        public async Task<ActionResult<ProductDto>> PostAsync(CreateProductDto createProductDto)
        {
            var product = new Product{
            Name = createProductDto.Name,
            Description = createProductDto.Description,
            Price = createProductDto.Price,
            Quantity = createProductDto.Quantity,
            ImageUrl = createProductDto.ImageUrl,
            CreatedDate = DateTimeOffset.UtcNow
            };
            await productsRepository.CreateAsync(product);
            return CreatedAtAction(nameof(GetByIdAsync),new { id = product.Id},product);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, UpdateProductDto updateProductDto)
        {
            var existingProduct = await productsRepository.GetAsync(id);
            if (existingProduct == null)
            {
                return NotFound();
            }
            existingProduct.Name = updateProductDto.Name;
            existingProduct.Description = updateProductDto.Description;
            existingProduct.Price = updateProductDto.Price;
            existingProduct.Quantity = updateProductDto.Quantity;
            existingProduct.ImageUrl = updateProductDto.ImageUrl;
            await productsRepository.UpdateAsync(existingProduct);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
             var product = await productsRepository.GetAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            await productsRepository.RemoveAsync(product.Id);
             return NoContent();
        }
    }
}