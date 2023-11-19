using Microsoft.AspNetCore.Mvc;
using OrderStoreApp.Services;
using OrderStoreCore.Models;
using System.ComponentModel.DataAnnotations;

namespace OrderStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [ApiVersion("1.0")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IServiceProvider provider)
        {
            _orderService = provider.GetService<IOrderService>();
        }
        [HttpGet("wel")]
        public async Task<IActionResult> GetOrder()
        {
            return Ok("Welcome");
        }

        [HttpGet("order")] 
        public async Task<IActionResult> GetOrder(string orderId)
        {
            var order = _orderService?.GetOrder(orderId);
            return Ok(order);
        }
        
        [HttpGet("orders")]
        public async Task<IActionResult> GetOrders(string criteria)
        {
            var orders = _orderService?.GetOrders(new SearchCriteria());
            return Ok(orders);
        }

        [HttpPost("create")]
        public async Task<IActionResult> NewOrderTrans([FromBody][Required] OrderCreateRequest request)
        {
            Order order = new Order()
            {
                Product = request.Product,
                Size = request.Size,
                Price = request.Price,
                Account = request.Account,
                Entity = request.Entity,
                Acronym = request.Acronym

            };

            var id = _orderService.Transaction().NewOrderTrans(order);
            return Ok(id);
        }
        [HttpPost("summary")]
        public async Task<IActionResult> GetSummary([FromBody][Required] OrderSummaryRequest request)
        {
            if(request == null)
                throw new ArgumentNullException(nameof(request));

            var orderId = request.OrderIds[0];
            var order = _orderService?.GetOrder(orderId);
            if(order == null)
                return NotFound();

            OrderSummary summary = new OrderSummary();
            summary.Notional =  order.Order.Size * 44;
            summary.NotionalUsd = 1200000;
            summary.MarketPercent = 0.5;

            return Ok(summary);
        }
    }
}
