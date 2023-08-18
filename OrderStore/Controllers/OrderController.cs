using Microsoft.AspNetCore.Mvc;
using OrderStoreApp.Services;

namespace OrderStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;

        public OrderController(IServiceProvider provider)
        {
            _orderService = provider.GetService<IOrderService>();
        }
        
        [HttpGet("order")] 
        public async Task<IActionResult> GetOrder(string orderId)
        {
            var order = _orderService?.GetOrder(orderId);
            return Ok(order);
        }
    }
}
