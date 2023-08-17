using Microsoft.Extensions.DependencyInjection;
using OrderStoreAdaptors.Cache;
using OrderStoreApp.Ports;

namespace OrderStoreAdaptors.Configurations
{
    public static class AdaptorExtensions
    {
        public static IServiceCollection AddAdaptorExtensions(this IServiceCollection services)
        {
            services.AddSingleton<IOrderCache, OrderCache>();
            return services;
        }
    }
}
