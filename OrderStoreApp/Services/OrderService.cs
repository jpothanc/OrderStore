using OrderStoreApp.Ports;
using Microsoft.Extensions.DependencyInjection;
using OrderStore;
using System.Reactive.Subjects;
using System.Reactive.Linq;
using OrderStoreCore.Models;
using OrderStoreApp.Interfaces;
using OrderStoreApp.Validators;

namespace OrderStoreApp.Services
{
    internal class OrderService : IOrderService
    {
        
        private readonly Subject<OrderEvent> _orderSubject;
        private IObservable<OrderEvent> _orderObservable;
        private IDisposable _orderSubscription;
        private readonly Subject<FillEvent> _fillSubject;
        private IObservable<FillEvent> _fillObservable;
        private IDisposable _fillSubscription;
        private IValidatorFactory _validatorFactory;


        private readonly IOrderTransaction _orderTransaction;
        private ICache _cache;

        public OrderService(IServiceProvider provider)
        {
            _orderSubject = new();
            _orderObservable = _orderSubject.AsObservable();
            _fillSubject = new();
            _fillObservable = _fillSubject.AsObservable();
            _cache = provider.GetService<ICache>();
            _orderTransaction = provider.GetService<IOrderTransaction>();
            _validatorFactory = provider.GetService<IValidatorFactory>();

        }
        public void Start()
        {
            _orderSubscription = _cache.SubscribeOrder(OnObserveOrder);
            _fillSubscription = _cache.SubscribeFill(OnObserveFill);
        }

        public void Stop()
        {
            _orderSubscription?.Dispose();
            _fillSubscription?.Dispose();
        }
        public OrderResponse GetOrder(string orderId)
        {
            return _cache.GetOrder(orderId);
        }

        public IDisposable SubscribeOrder(Action<OrderEvent> action)
        {
            return _orderObservable.Subscribe(action);
        }

        public IDisposable SubscribeFill(Action<FillEvent> action)
        {
            return _fillObservable.Subscribe(action);
        }

        private void OnObserveOrder(OrderEvent order)
        {
            _orderSubject.OnNext(order);
        }

        private void OnObserveFill(FillEvent fill)
        {
            _fillSubject.OnNext(fill);
        }

        public IOrderTransaction Transaction()
        {
            return _orderTransaction;
        }
    }
}
