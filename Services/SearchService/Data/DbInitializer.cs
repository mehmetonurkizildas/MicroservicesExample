using MongoDB.Driver;
using MongoDB.Entities;
using SearchService.Models;
using SearchService.Services;

namespace SearchService.Data
{
    public class DbInitializer
    {
        public static async Task InitDb(WebApplication app)
        {
            await DB.InitAsync("SearchDb", MongoClientSettings
                       .FromConnectionString(app.Configuration.GetConnectionString("MongoDbConnection")));

            await DB.Index<Product>()
                .Key(x => x.Brand, KeyType.Text)
                .Key(x => x.StockStatus, KeyType.Text)
                .CreateAsync();

            var count = await DB.CountAsync<Product>();

            using var scope = app.Services.CreateScope();

            var httpClient = scope.ServiceProvider.GetRequiredService<ProductServiceHttpClient>();

            var products = await httpClient.GetProductsForSearchDb();
            Console.WriteLine(products.Count + " returned from the product service");

            if (products.Count > 0) await DB.SaveAsync(products);
        }
    }
}
