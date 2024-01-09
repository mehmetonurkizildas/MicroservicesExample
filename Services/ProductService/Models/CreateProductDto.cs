using ProductService.Entities;

namespace ProductService.Models
{
    public record CreateProductDto(string Name, string Brand, double Price, string Description, string ImageUrl, StockStatus StockStatus)
    {
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
