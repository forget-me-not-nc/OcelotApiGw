using Microsoft.AspNetCore.Mvc;
using OrderAggregator.Extensions;
using OrderAggregator.Models;
using OrderAggregator.Services;

namespace OrderAggregator.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderAggregatorController : ControllerBase
    {

        private readonly IArchiveService archiveService;
        private readonly IBasketService basketService;
        private readonly IDataService dataService;
        public OrderAggregatorController(IArchiveService archiveService, IBasketService basketService, IDataService dataService)
        {
            this.archiveService = archiveService ?? throw new ArgumentNullException(nameof(archiveService));
            this.basketService = basketService ?? throw new ArgumentNullException(nameof(basketService));
            this.dataService = dataService ?? throw new ArgumentNullException(nameof(dataService));
        }

        [HttpPost("create")]
        public async Task<ActionResult<Order>> createOrder(OrderCreateModel model)
        {
            var basket = await basketService.GetBasket(model.ClientId);
            var order = new Order
            {
                Address = new string(
                    model.Address.Country + ',' +
                    model.Address.State + ',' +
                    model.Address.City + ',' +
                    model.Address.Street),
                ClientId = model.ClientId,
                Books = new List<BookDTO>(),
                TotalPrice = decimal.Zero,
                Date = DateTime.Now.ToString(DateUtils.GetDateFormat(), DateUtils.GetDateProvider())
            };

            foreach(int id in basket.ItemIds)
            {
                var book = await dataService.GetBookById(id);

                order.Books.Add(book);
                order.TotalPrice += book.Price;
            }

            var orderId = (await archiveService.CreateOrder(order));

            order.Id = orderId;

            return Ok(order);
        }  
    }
}
