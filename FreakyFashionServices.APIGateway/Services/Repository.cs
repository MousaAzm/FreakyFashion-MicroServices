using FreakyFashionServices.APIGateway.Models.Dtos;
using Newtonsoft.Json;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace FreakyFashionServices.APIGateway.Services
{
    public class Repository : IRepository
    {
        private readonly string basketUrl = "http://localhost:5000/api/basket/";
        private readonly string productUrl = "http://localhost:5100/api/product";
        private readonly string orderUrl = "http://localhost:5200/api/order";
        private readonly string stockUrl = "http://localhost:5300/api/stock";
        private readonly IHttpClientFactory _httpClient;

        public Repository(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<ReadProductDto>> GetProdcut()
        {
            string url = productUrl;
            var stock = await GetStock();

            var response = await _httpClient.CreateClient().GetStringAsync(url);
            var products = JsonConvert.DeserializeObject<IEnumerable<ReadProductDto>>(response);
            var result = products.Select(p => new ReadProductDto
            {
                Id = p.Id,
                ArticleNumber = p.ArticleNumber,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                Name = p.Name,
                StockLevel = stock.Where(s => s.ArticleNumber == p.ArticleNumber)
                          .Select(m => m.StockLevel)
                          .FirstOrDefault(),
                UrlSlug = p.UrlSlug,
                Price = p.Price,
            });
            return result;

        }

        public async Task<ProductDto> CreateProduct(CreateProductDto createProductDto)
        {
            string url = productUrl;
            string json = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _httpClient.CreateClient().PostAsync(url, stringContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductDto>(content);
        }

        public async Task<ProductDto> UpdateProduct(string articleNumber, CreateProductDto createProductDto)
        {
            string url = productUrl + "/" + articleNumber;
            string json = JsonConvert.SerializeObject(createProductDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _httpClient.CreateClient().PutAsync(url, stringContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ProductDto>(content);
        }

        public async Task<IEnumerable<StockDto>> GetStock()
        {
            string url = stockUrl;
            var response = await _httpClient.CreateClient().GetStringAsync(url);
            return JsonConvert.DeserializeObject<IEnumerable<StockDto>>(response);
        }

        public void UpdateStock(string articleNumber, StockDto stockDto)
        {
            string url = stockUrl + "/" + articleNumber;
            string json = JsonConvert.SerializeObject(stockDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
            _httpClient.CreateClient().PutAsync(url, stringContent);
        }

        public async Task<ReadCartDto> GetBasket(string articleNumber)
        {
            string url = basketUrl + articleNumber;
            var response = await _httpClient.CreateClient().GetStringAsync(url);
            return JsonConvert.DeserializeObject<ReadCartDto>(response);
        }

        public async Task<ReadCartDto> CreateBasket(string articleNumber, CreateCartDto createCartDto)
        {
            string url = basketUrl + articleNumber;
            string json = JsonConvert.SerializeObject(createCartDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _httpClient.CreateClient().PutAsync(url, stringContent);
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReadCartDto>(content);
        }

        public async Task<ReadOrderDto> CreateOrder(CreateOrderDto createOrderDto)
        {
            string url = orderUrl;
            string json = JsonConvert.SerializeObject(createOrderDto);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, Application.Json);
            var response = await _httpClient.CreateClient().PostAsync(url, stringContent);
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<ReadOrderDto>(content);
        }

    }
}
