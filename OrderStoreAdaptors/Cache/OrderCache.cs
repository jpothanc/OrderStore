using OrderStore;
using OrderStoreApp.Ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreAdaptors.Cache
{
    internal class OrderCache : IOrderCache
    {
        public void Add(OrderReply order)
        {
            //throw new NotImplementedException();
        }

        public OrderReply Get(string id)
        {
            return new OrderReply
            {
                Orderid = "test",
                Acronym = "F10"
            };
        }
    }
}
