using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators
{
    internal interface IValidator
    {
        Type Type { get; }
        void Validate<T>(T item);
    }
}
