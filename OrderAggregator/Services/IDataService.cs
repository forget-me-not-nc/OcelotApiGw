using OrderAggregator.Models;

namespace OrderAggregator.Services
{
    public interface IDataService
    {
        Task<BookDTO> GetBookById(int id);
    }
}
