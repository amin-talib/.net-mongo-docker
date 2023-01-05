using Food.Products.Services.Dtos;
using Food.Products.Services.Entities;

namespace Food.Products.Services
{
    public static class Extensions
    {
        public static ProductDto AsDto(this Product product)
        {
            return new ProductDto(product.Id,product.Name,product.Description,product.Price,product.Quantity,product.ImageUrl,product.CreatedDate);
        }
    }
}