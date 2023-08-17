using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Ports
{
    public interface IOrderCache
    {
        void Add(OrderReply order);
        OrderReply Get(string id);

    }
}
