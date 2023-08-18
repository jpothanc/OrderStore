using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreCore.Models
{
    public class OrderEvent
    {
        public OrderEvent(Order order, OrderEventType eventType = OrderEventType.New)
        {
            EventType = eventType;
            Order = order;
        }
       
        public OrderEventType EventType { get; private set; }
        public Order Order { get; private set; }
    }
    public enum OrderEventType
    {
        New,
        Update,
        Cancel
    };
}
