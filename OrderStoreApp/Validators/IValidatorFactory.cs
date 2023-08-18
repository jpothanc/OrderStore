using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators
{
    internal interface IValidatorFactory
    {
        IValidator GetValidator(Type type);
    }
}
