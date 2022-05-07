using Newtonsoft.Json;
using OrderAggregator.Models;

namespace OrderAggregator.Services.Impls
{
    public class BascketService : IBasketService
    {

        private readonly HttpClient _httpClient;

        public BascketService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<Basket> GetBasket(int clientId)
        {
            var response = await _httpClient.GetAsync("/api/basket/" + clientId);
            return JsonConvert.DeserializeObject<Basket>(await response.Content.ReadAsStringAsync());
        }
    }
}
