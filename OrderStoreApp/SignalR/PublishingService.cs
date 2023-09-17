using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using OrderStore;
using OrderStoreApp.Hub;
using OrderStoreApp.Interfaces;
using OrderStoreApp.Services;
using System.Reflection;
using System.Text.Json;

namespace OrderStoreApp.SignalR
{
    public class PublishingService : IPublishingService 
    {
        private readonly IServiceProvider _provider;
        private readonly IOrderService _orderService;

        public PublishingService(IServiceProvider provider)
        {
            _orderService = provider.GetService<IOrderService>();
            _provider = provider;
           

        }
        public async Task Add(Order order)
        {
            await PublishMessage(order);
        }

        public void Start()
        {
            _orderService?.SubscribeOrder(async x =>
            {
                await Add(x.Order);
            });
        }

        public void Stop()
        {
        }

        private async Task PublishMessage(Order order)
        {
            var scope = _provider.CreateScope();
            var hub  = scope.ServiceProvider.GetRequiredService<IHubContext<NotificationHub>>();
            if (hub == null)
                return;
            var s = order.ToString();
            await hub.Clients.Group("orders").SendAsync("notify", order.ToString());
        }

        public static string ToString<T>(T model)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            string result = $"{type.Name} {{";

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(model);
                string valueString = (value != null) ? value.ToString() : "null";

                result += $" {property.Name}: {valueString},";
            }

            // Remove the trailing comma and add closing curly brace
            result = result.TrimEnd(',') + " }";

            return result;
        }

        public static string ToJson<T>(T model)
        {
            Type type = typeof(T);
            PropertyInfo[] properties = type.GetProperties();

            var jsonDictionary = new Dictionary<string, object>();

            foreach (PropertyInfo property in properties)
            {
                object value = property.GetValue(model);
                if (property.Name == "State")
                {
                    string valueString = (value != null) ? value.ToString() : "null";
                    jsonDictionary[property.Name] = valueString;

                }
                else
                                 jsonDictionary[property.Name] = value;
            }

            string jsonString = JsonSerializer.Serialize(jsonDictionary);
            return jsonString;
        }
    }
}

