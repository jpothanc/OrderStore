using OrderStoreApp.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using OrderStoreApp.SignalR;

namespace OrderStoreApp.Services
{
    public class Startup : IService
    {

        private readonly IOrderService _orderService;
        private readonly IPublishingService _publishingService;
        public Startup(IServiceProvider provider)
        {
            _orderService = provider.GetService<IOrderService>();
            _publishingService = provider.GetService<IPublishingService>();
        }
        public void Start()
        {
            _orderService.Start();
            _publishingService.Start();

        }

        public void Stop()
        {
            _orderService.Stop();
        }
    }
}

