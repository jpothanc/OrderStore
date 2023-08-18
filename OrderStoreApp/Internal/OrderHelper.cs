using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Internal
{
    public static class OrderHelper
    {
        public static void SetDefaults(this Order order)
        {
            order.State = State.Live;
        }
    }
}
