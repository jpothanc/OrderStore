using Grpc.Core;
using OrderStoreApp.Services;

namespace OrderStore.Grpc
{
    public class OrderProviderService : OrderProvider.OrderProviderBase
    {
        private readonly ILogger<OrderProviderService> _logger;
        private readonly IOrderService _orderService;

        public OrderProviderService(ILogger<OrderProviderService> logger, IServiceProvider provider)
        {
            _logger = logger;
            _orderService = provider.GetService<IOrderService>();
        }
        
        public override Task<OrderResponse> GetOrder(OrderRequest request, ServerCallContext context)
        {
            var response = _orderService?.GetOrder(request.Orderid);
            return Task.FromResult(response);
        }
        public override async Task SubscribeOrder(OrderCriteria request, 
            IServerStreamWriter<Order> responseStream, 
            ServerCallContext context)
        {
            _orderService.SubscribeOrder(x =>
            {
                if (x != null)
                {
                    responseStream.WriteAsync(x.Order);
                    Console.WriteLine($"Order Received {x.Order.Orderid}");
                }
            });
            while (!context.CancellationToken.IsCancellationRequested) ;
        }

        public override async Task SubscribeFill(FillCriteria request,
            IServerStreamWriter<Fill> responseStream,
            ServerCallContext context)
        {
            _orderService.SubscribeFill(x =>
            {
                if (x != null)
                {
                    responseStream.WriteAsync(x.Fill);
                    Console.WriteLine($"Fill Received {x.Fill}");
                }
            });
            while (!context.CancellationToken.IsCancellationRequested) ;
        }


    }
}
