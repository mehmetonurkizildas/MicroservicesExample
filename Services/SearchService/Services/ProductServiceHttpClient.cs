using SearchService.Models;

namespace SearchService.Services
{
    public class ProductServiceHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public ProductServiceHttpClient(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<List<Product>> GetProductsForSearchDb()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>(_config["ProductServiceUrl"] + "/api/product");
        }
    }
}
