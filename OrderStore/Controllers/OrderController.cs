using Microsoft.AspNetCore.Mvc;

namespace OrderStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        public async Task<IActionResult> Get()
        {
            return Ok(new OrderReply
            {
                Orderid = "test",
                Acronym = "F10"
            });
        }
    }
}
