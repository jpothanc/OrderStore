using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Ports
{
    public interface IHistoryCache
    {
        void Recover();
        void Save();
    }
}
