using OrderStoreApp.Ports;
using Microsoft.Extensions.DependencyInjection;
using OrderStore;
using OrderStoreCore.Models;
using OrderStoreApp.Interfaces;
using System.Reactive.Linq;
using System.Reactive.Concurrency;
using OrderStoreApp.Validators.FilterChain;

namespace OrderStoreApp.Services
{
    internal class OrderService : IOrderService
    {
        private IItemObserver<OrderEvent> _orderObserver;
        private IItemObserver<FillEvent> _fillObserver;
        private readonly IOrderTransaction _orderTransaction;
        private ICache _cache;
        private IFilterChain<OrderEvent> _orderFilterChain;


        public OrderService(IServiceProvider provider)
        {
            _orderObserver = new ItemObserver<OrderEvent>();
            _fillObserver = new ItemObserver<FillEvent>();

            _cache = provider.GetService<ICache>();
            _orderTransaction = provider.GetService<IOrderTransaction>();
            _orderFilterChain = provider.GetService<IFilterChainFactory>()?.CreateOrderFilters("");

        }
        public void Start()
        {
            SubscribeOrderEvents();
            SubscribeFillEvents();
        }

        private void SubscribeFillEvents()
        {
            _cache.SubscribeFill().
                           ObserveOn(TaskPoolScheduler.Default).
                           Subscribe(fillEvent =>
                           {
                               Console.WriteLine($"SubscribeFill {fillEvent.Fill.Fillid} : " +
                                   $"{Thread.CurrentThread.Name}:{Thread.CurrentThread.ManagedThreadId}");
                               _fillObserver.Notify(fillEvent);
                           });
        }

        private void SubscribeOrderEvents()
        {
            _cache.SubscribeOrder()
               .SubscribeOn(NewThreadScheduler.Default)
               .Select(async orderEvent => await _orderFilterChain.Process(orderEvent))
                .ObserveOn(Scheduler.CurrentThread)
                .Subscribe(async orderEvent =>
                {
                    Console.WriteLine($"SubscribeOrder {orderEvent.Result.Order.Orderid} : " +
                        $"{Thread.CurrentThread.Name}:{Thread.CurrentThread.ManagedThreadId}");
                    _orderObserver.Notify(orderEvent.Result);

                }, error => Console.WriteLine($"Error: {error.Message}"),
                () => Console.WriteLine("Completed"));
        }

        public OrderResponse GetOrder(string orderId)
        {
            return _cache.GetOrder(orderId);
        }
        public List<Order> GetOrders(SearchCriteria criteria)
        {
            return _cache.GetOrders(criteria);
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
        public void Stop()
        {

        }
    }
}
