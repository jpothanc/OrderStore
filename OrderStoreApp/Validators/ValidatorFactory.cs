using OrderStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Validators
{
    internal class ValidatorFactory : IValidatorFactory
    {
        private IEnumerable<IValidator> _validators;

        public ValidatorFactory(IEnumerable<IValidator> validators)
        {
            _validators = validators;
        }


        public IValidator GetValidator(Type type)
        {
           return _validators.Where(x => x.Type == type).ToList().FirstOrDefault();   
        }
    }
}
