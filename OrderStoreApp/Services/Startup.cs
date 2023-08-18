using OrderStoreApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace OrderStoreApp.Services
{
    public class Startup : IService
    {

        private readonly IOrderService _orderService; 
        public Startup(IServiceProvider provider)
        {
            _orderService = provider.GetService<IOrderService>();
        }
        public void Start()
        {
            _orderService.Start();
        }

        public void Stop()
        {
            _orderService.Stop();
        }
    }
}
