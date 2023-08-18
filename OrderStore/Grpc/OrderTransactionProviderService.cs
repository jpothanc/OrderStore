using Grpc.Core;
using OrderStoreApp.Services;
using System.Security.Principal;

namespace OrderStore.Grpc
{
    public class OrderTransactionProviderService : OrderStore.OrderTransactionProvider.OrderTransactionProviderBase
    {

        private readonly ILogger<OrderProviderService> _logger;
        private readonly IOrderService _orderService;

        public OrderTransactionProviderService(ILogger<OrderProviderService> logger, IServiceProvider provider)
        {
            _logger = logger;
            _orderService = provider.GetService<IOrderService>();
        }
        public override Task<OrderId> NewOrderTrans(Order request, ServerCallContext context)
        {
            var id =  _orderService.Transaction().NewOrderTrans(request);
            return Task.FromResult(new OrderId()
            {
                Orderid = id
            });
        }

        public override Task<OrderId> CancelOrderTrans(OrderId request, ServerCallContext context)
        {
            return Task.FromResult(new OrderId()
            {
                Orderid = request.Orderid
            });
        }

        public override Task<FillId> NewFillTrans(Fill request, ServerCallContext context)
        {
            var id = _orderService.Transaction().NewFillTrans(request);
            return Task.FromResult(new FillId()
            {
                Fillid = id
            });
        }
    }
}
