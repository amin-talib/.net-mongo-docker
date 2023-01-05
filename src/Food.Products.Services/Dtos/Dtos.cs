using System.ComponentModel.DataAnnotations;

namespace Food.Products.Services.Dtos
{
    public record ProductDto(Guid Id,string Name,string Description,decimal Price,decimal Quantity, string ImageUrl,DateTimeOffset CreatedDate);
    public record CreateProductDto([Required] string Name,string Description,[Range(0,1000)] decimal Price,[Range(0,1000)] decimal Quantity, string ImageUrl);
    public record UpdateProductDto([Required]string Name,string Description,[Range(0,1000)] decimal Price,[Range(0,1000)] decimal Quantity, string ImageUrl);
}