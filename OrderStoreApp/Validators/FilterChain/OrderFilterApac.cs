using OrderStore;
using OrderStoreCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators.FilterChain
{
    internal class OrderFilterApac : IFilterChain<OrderEvent>
    {
        public IFilterChain<OrderEvent> Next { get; set; }

        public async Task<OrderEvent> Process(OrderEvent item)
        {
            Console.WriteLine("Processing: " + this.GetType().Name);
            item.Order.Entity = "CSFBJL";

            if (Next != null)
            {
                return await Next.Process(item);
            }
            return item;
        }
    }
}
