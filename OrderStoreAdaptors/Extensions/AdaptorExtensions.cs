using Microsoft.Extensions.DependencyInjection;
using OrderStoreAdaptors.Cache;
using OrderStoreApp.Ports;

namespace OrderStoreAdaptors.Extensions
{
    public static class AdaptorExtensions
    {
        public static IServiceCollection AddAdaptorExtensions(this IServiceCollection services)
        {
            services.AddSingleton<ICache, InMemoryCache>();
            return services;
        }
    }
}
