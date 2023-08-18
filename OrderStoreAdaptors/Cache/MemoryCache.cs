using OrderStore;
using OrderStoreApp.Ports;
using OrderStoreCore.Models;
using System.Collections.Concurrent;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace OrderStoreAdaptors.Cache
{
    internal class MemoryCache : ICache
    {
        
        private readonly Subject<OrderEvent> _orderSubject;
        private IObservable<OrderEvent> _orderObservable;
        private readonly Subject<FillEvent> _fillSubject;
        private IObservable<FillEvent> _fillObservable;
        private ConcurrentDictionary<string, Order> _orderCache;
        private ConcurrentDictionary<string, Fill> _fillCache;

        public MemoryCache()
        {
            _orderSubject = new();
            _orderObservable = _orderSubject.AsObservable();

            _fillSubject = new();
            _fillObservable = _fillSubject.AsObservable();

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
            order.Orderid = Guid.NewGuid().ToString();
            _orderCache.TryAdd(order.Orderid, order);
            _orderSubject.OnNext(new OrderEvent(order));
            return order.Orderid;
        }
        private string AddFill(Fill fill)
        {
            fill.Fillid = Guid.NewGuid().ToString();
            _fillCache.TryAdd(fill.Fillid, fill);
            _fillSubject.OnNext(new FillEvent(fill));
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
        public IDisposable SubscribeOrder(Action<OrderEvent> action)
        {
            return _orderObservable.Subscribe(action);
        }
        public IDisposable SubscribeFill(Action<FillEvent> action)
        {
            return _fillObservable.Subscribe(action);
        }

        public string Update(Order order)
        {
            _orderCache.TryAdd(order.Orderid, order);
            _orderSubject.OnNext(new OrderEvent(order, OrderEventType.Update));
            return order.Orderid;
        }

        private async Task OrderGenerator()
        {
            
            while (true)
            {
                var o = new Order
                {
                    Orderid = Guid.NewGuid().ToString(),
                    Acronym = "F10"
                };

                _orderSubject.OnNext(new OrderEvent(o));
                await Task.Delay(100);
            }
        }

       
    }
}
