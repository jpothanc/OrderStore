using OrderStoreApp.Ports;
using Microsoft.Extensions.DependencyInjection;
using OrderStore;
using OrderStoreCore.Models;
using OrderStoreApp.Interfaces;
using OrderStoreApp.Validators;

namespace OrderStoreApp.Services
{
    internal class OrderService : IOrderService
    {
        private IItemObserver<OrderEvent> _orderObserver;
        private IItemObserver<FillEvent> _fillObserver;
        private readonly IOrderTransaction _orderTransaction;
        private ICache _cache;

        public OrderService(IServiceProvider provider)
        {
            _orderObserver = new ItemObserver<OrderEvent>();
            _fillObserver = new ItemObserver<FillEvent>();

            _cache = provider.GetService<ICache>();
            _orderTransaction = provider.GetService<IOrderTransaction>();

        }
        public void Start()
        {
            _cache.SubscribeOrder(orderEvent =>
            {
                _orderObserver.Notify(orderEvent);
            });
            _fillObserver.Subscribe(fillEvent =>
            {
                _fillObserver.Notify(fillEvent);

            });
        }

        public void Stop()
        {
        }
        public OrderResponse GetOrder(string orderId)
        {
            return _cache.GetOrder(orderId);
        }

        public void SubscribeOrder(Action<OrderEvent> action)
        {
            _orderObserver.Subscribe(action);
        }

        public void SubscribeFill(Action<FillEvent> action)
        {
            _fillObserver.Subscribe(action);
        }

        public IOrderTransaction Transaction()
        {
            return _orderTransaction;
        }
    }
}
