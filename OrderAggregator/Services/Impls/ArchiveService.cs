using Newtonsoft.Json;
using OrderAggregator.Models;
using System.Text;

namespace OrderAggregator.Services.Impls
{
    public class ArchiveService : IArchiveService
    {
        private readonly HttpClient _httpClient;

        public ArchiveService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<string> CreateOrder(Order order)
        {
            var json = JsonConvert.SerializeObject(order);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/order", data);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
