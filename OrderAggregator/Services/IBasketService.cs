using OrderAggregator.Models;

namespace OrderAggregator.Services
{
    public interface IBasketService
    {
        Task<Basket> GetBasket(int clientId);
    }
}
