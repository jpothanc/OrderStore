using OrderStore;
using OrderStoreApp.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OrderStoreApp.Services
{
    internal class OrderService : IOrderService
    {
        IOrderCache _cache;
        public OrderService(IServiceProvider provider)
        {
            _cache = provider.GetService<IOrderCache>();
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void Subscribe(Action<OrderReply> handler)
        {
            Task.Run(() => GenerateOrders(handler));
        }

        async Task GenerateOrders(Action<OrderReply> handler)
        {
            while(true)
            {
                await Task.Delay(1000);
                var o = new OrderReply
                {
                    Orderid = Guid.NewGuid().ToString(),
                    Acronym = "HSBC"

                };
                handler(o);
            }

        }
    }
}
