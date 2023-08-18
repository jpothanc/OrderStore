using OrderStore;
using OrderStoreCore.Models;

namespace OrderStoreApp.Ports
{
    public interface ICache
    {
        string Add<T>(T order);
        string Update(Order order);
        OrderResponse GetOrder(string id);

        IDisposable SubscribeOrder(Action<OrderEvent> action);
        IDisposable SubscribeFill(Action<FillEvent> action);

    }
}
