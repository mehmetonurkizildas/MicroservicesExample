using Bogus;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using ProductService.Entities;

namespace ProductService.Data
{
    public class ProductDbContext : DbContext
    {
        public ProductDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // add in memory outbox https://masstransit.io/documentation/patterns/in-memory-outbox
            builder.AddInboxStateEntity();
            builder.AddOutboxMessageEntity();
            builder.AddOutboxStateEntity();

            // Seed data
            var faker = new Faker<Product>()
                     .RuleFor(p => p.Id, f => f.Random.Guid())
                     .RuleFor(p => p.Name, f => f.Commerce.ProductName())
                     .RuleFor(p => p.Brand, f => f.Company.CompanyName())
                     .RuleFor(p => p.Price, f => f.Random.Double(10, 1000))
                     .RuleFor(p => p.Description, f => f.Commerce.ProductDescription())
                     .RuleFor(p => p.ImageUrl, f => f.Image.LoremPixelUrl())
                     .RuleFor(p => p.StockStatus, f => f.Random.Enum<StockStatus>())
                     ;


            var products = faker.Generate(20); // 20 adet ürün oluşturuldu

            builder.Entity<Product>().HasData(products);

        }
    }
}
