using OrderStore;
using OrderStoreApp.Ports;
using OrderStoreApp.Services;
using OrderStoreCore.Models;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace OrderStoreAdaptors.Cache
{
    public class InMemoryCache : ICache
    {

        private IItemObserver<OrderEvent> _orderObserver;
        private IItemObserver<FillEvent> _fillObserver;
        private ConcurrentDictionary<string, Order> _orderCache;
        private ConcurrentDictionary<string, Fill> _fillCache;

        public InMemoryCache()
        {
            _orderObserver = new ItemObserver<OrderEvent>();
            _fillObserver = new ItemObserver<FillEvent>();
            _orderCache = new();
            _fillCache = new();
        }

        public string Add<T>(T item)
        {
            return item switch
            {
                Order order => AddOrder(order),
                Fill fill => AddFill(fill),
                _ => string.Empty
            };
        }

        private string AddOrder(Order order)
        {
            Console.WriteLine($"AddOrder {order.Orderid} : {Thread.CurrentThread.Name}:{Thread.CurrentThread.ManagedThreadId}");
            order.Orderid = Guid.NewGuid().ToString();
            _orderCache.TryAdd(order.Orderid, order);
            _orderObserver.Notify(new OrderEvent(order));
            return order.Orderid;
        }
        private string AddFill(Fill fill)
        {
            fill.Fillid = Guid.NewGuid().ToString();
            _fillCache.TryAdd(fill.Fillid, fill);
            _fillObserver.Notify(new FillEvent(fill));
            return fill.Fillid;
        }

        public OrderResponse GetOrder(string id)
        {
            _ = _orderCache.TryGetValue(id, out Order order);

            return new OrderResponse()
            {
                Order = order,
                Hasvalue = order != null
            };
        }

        public string Update(Order order)
        {
            _orderCache.TryAdd(order.Orderid, order);   
            _orderObserver.Notify(new OrderEvent(order, OrderEventType.Update));
            return order.Orderid;
        }

        public IObservable<OrderEvent> SubscribeOrder()
        {
            return _orderObserver.Subscribe();
        }
        public IObservable<FillEvent> SubscribeFill()
        {
            return _fillObserver.Subscribe();
        }
    }
}

