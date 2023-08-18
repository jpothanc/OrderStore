using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators
{
    internal class FillValidator : IValidator
    {
        public Type Type => typeof(Fill);

        public void Validate<T>(T item)
        {
            Console.WriteLine("Fill Validation here....");
        }
    }
}
