using OrderStore;
using OrderStoreCore.Models;

namespace OrderStoreApp.Ports
{
    public interface ICache
    {
        string Add<T>(T order);
        string Update(Order order);
        OrderResponse GetOrder(string id);
        List<Order> GetOrders(SearchCriteria criteria);
        IObservable<OrderEvent> SubscribeOrder();
        IObservable<FillEvent> SubscribeFill();

    }
}
