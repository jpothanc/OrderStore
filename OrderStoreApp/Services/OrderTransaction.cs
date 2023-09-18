using Microsoft.Extensions.DependencyInjection;
using OrderStore;
using OrderStoreApp.Interfaces;
using OrderStoreApp.Internal;
using OrderStoreApp.Ports;
using OrderStoreApp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Services
{
    internal class OrderTransaction : IOrderTransaction
    {
        private ICache _cache;
        private IValidator _validator;
        public OrderTransaction(IServiceProvider provider)
        {
            _cache = provider.GetService<ICache>();
            var validatorFactory = provider.GetService<IValidatorFactory>();
            _validator = validatorFactory?.GetValidator(typeof(Order));
        }

        public string CancelOrderTrans(string orderId)
        {
            var response =  _cache.GetOrder(orderId);
            if (!response.Hasvalue)
                return string.Empty;

            response.Order.State = State.Cxl.ToString();
            _cache.Update(response.Order);
            return orderId;
        }

        public string NewFillTrans(Fill fill)
        {
            return _cache.Add(fill);
        }

        public string NewOrderTrans(Order order)
        {
            _validator.Validate(order);
            order.SetDefaults();
            return _cache.Add(order);
        }
        
    }
}
