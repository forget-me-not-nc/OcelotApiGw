using OrderAggregator.Models;

namespace OrderAggregator.Services
{
    public interface IArchiveService
    {
        Task<string> CreateOrder(Order order);
    }
}
