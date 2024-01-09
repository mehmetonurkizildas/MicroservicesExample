using MongoDB.Entities;

namespace SearchService.Models
{
    public class Product : Entity
    {
        public required string Name { get; set; }
        public required string Brand { get; set; }
        public double Price { get; set; }
        public required string Description { get; set; }
        public required string ImageUrl { get; set; }
        public required string StockStatus { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
