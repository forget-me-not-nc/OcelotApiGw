using Newtonsoft.Json;
using OrderAggregator.Models;

namespace OrderAggregator.Services.Impls
{
    public class DataService : IDataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            var response = await _httpClient.GetAsync("api/book/" + id);

            return JsonConvert.DeserializeObject<BookDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}
