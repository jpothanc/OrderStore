using OrderStore;
using OrderStoreApp.Interfaces;

namespace OrderStoreApp.Interfaces
{
    public interface IPublishingService : IService
    {
        Task Add(Order order);
    }
}

