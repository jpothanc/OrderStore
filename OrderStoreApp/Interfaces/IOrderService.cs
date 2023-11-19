
using OrderStore;
using OrderStoreApp.Interfaces;
using OrderStoreCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Services
{
    public interface IOrderService
    {
        void Start();
        void Stop();
        void SubscribeOrder(Action<OrderEvent> action);
        void SubscribeFill(Action<FillEvent> action);
        IOrderTransaction Transaction();

        OrderResponse GetOrder(string orderId);
        List<Order> GetOrders(SearchCriteria criteria);
    }
}
