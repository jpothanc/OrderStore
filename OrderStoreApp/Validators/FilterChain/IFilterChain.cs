using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators.FilterChain
{
    public interface IFilterChain<T>
    {
        IFilterChain<T> Next { get; set; }
        Task<T> Process(T item);
    }
}
