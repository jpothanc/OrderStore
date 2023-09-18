using OrderStore;
using OrderStoreCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators.FilterChain
{
    public interface IFilterChainFactory
    {
        IFilterChain<OrderEvent> CreateOrderFilters(string filters);
        IFilterChain<FillEvent> CreateFillFilters(string filters);
    }
    public class FilterChainFactory: IFilterChainFactory
    {
        public IFilterChain<FillEvent> CreateFillFilters(string filters)
        {
            throw new NotImplementedException();
        }

        public IFilterChain<OrderEvent> CreateOrderFilters(string filters)
        {
            IFilterChain<OrderEvent> filter1 = new OrderFilterBase();
            IFilterChain<OrderEvent> filter2 = new OrderFilterApac();
            filter1.Next = filter2;
            return filter1;
        }
    }
}
