using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators
{
    internal class OrderValidator : IValidator
    {
        public Type Type => typeof(Order);
        public void Validate<T>(T item)
        {
            Console.WriteLine("Order Validation here....");
        }
    }
}
