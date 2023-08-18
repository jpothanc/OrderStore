using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Interfaces
{
    public interface IOrderTransaction
    {
        string NewOrderTrans(Order order);
        string CancelOrderTrans(string order);
        string NewFillTrans(Fill fill);
    }
}
