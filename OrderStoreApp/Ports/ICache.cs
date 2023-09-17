using OrderStore;
using OrderStoreCore.Models;

namespace OrderStoreApp.Ports
{
    public interface ICache
    {
        string Add<T>(T order);
        string Update(Order order);
        OrderResponse GetOrder(string id);

        void SubscribeOrder(Action<OrderEvent> action);
        void SubscribeFill(Action<FillEvent> action);

    }
}
