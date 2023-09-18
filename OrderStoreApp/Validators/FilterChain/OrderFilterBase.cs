using OrderStore;
using OrderStoreCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators.FilterChain
{
    internal class OrderFilterBase : IFilterChain<OrderEvent>
    {
        public IFilterChain<OrderEvent> Next { get; set; }

        public async Task<OrderEvent> Process(OrderEvent item)
        {
            Console.WriteLine("Processing: " + this.GetType().Name + $"{Thread.CurrentThread.Name}:{Thread.CurrentThread.ManagedThreadId}");
            item.Order.Account = "KD8";

            if (Next != null)
            {
                return await Next.Process(item);
            }
            return item;
        }
    }
}
