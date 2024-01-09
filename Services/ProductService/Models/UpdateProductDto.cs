using ProductService.Entities;

namespace ProductService.Models
{
    public record UpdateProductDto(string Name, string Brand, double Price, string Description, string ImageUrl, StockStatus StockStatus, DateTime CreatedAt, DateTime UpdatedAt);
}
