using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Services
{
    internal interface IOrderService
    {
        void Start();
        void Stop();
        void Subscribe(Action<OrderReply> handler);
    }
}
