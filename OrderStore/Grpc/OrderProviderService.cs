using Grpc.Core;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace OrderStore.Grpc
{
    public class OrderProviderService : OrderProvider.OrderProviderBase
    {
        private readonly ILogger<OrderProviderService> _logger;

        public OrderProviderService(ILogger<OrderProviderService> logger)
        {
            _logger = logger;
        }

        
        public override Task<OrderReply> GetOrder(OrderRequest request, ServerCallContext context)
        {
            return Task.FromResult( new  OrderReply
            {
                Orderid = "test",
                Acronym = "F10"
            });
        }
    }
}
