﻿using Microsoft.Extensions.DependencyInjection;
using OrderStoreApp.Interfaces;
using OrderStoreApp.Services;
using OrderStoreApp.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Extensions
{
    public static class AppExtensions
    {
        public static IServiceCollection AddAppExtensions(this IServiceCollection services)
        {
            services.AddSingleton<Startup>();
            services.AddSingleton<IOrderService,OrderService>();
            services.AddSingleton<IOrderTransaction, OrderTransaction>();
            services.AddSingleton<IValidatorFactory, ValidatorFactory>();
            services.AddSingleton<IValidator,FillValidator >();
            services.AddSingleton<IValidator,OrderValidator>();
            return services;
        }
    }
}
