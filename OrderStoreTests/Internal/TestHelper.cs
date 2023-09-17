using OrderStore;
using OrderStoreCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreTests.Internal
{
    public static class TestHelper
    {

        public static Order GetOrder()
        {
            return new Order()
            {
                Orderid = Guid.NewGuid().ToString(),
                Acronym = "F10",
                Size = 100,
                Price = "LMT:44",
                Product = "0005.HK",
                Account = "KD8"
            };
        }
        public static OrderEvent GetNewOrderEvent()
        {
            return new OrderEvent(GetOrder(), OrderEventType.New);
           
        }
        
    }
}
