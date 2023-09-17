using Microsoft.AspNetCore.SignalR;
using OrderStoreApp.Interfaces;

namespace OrderStoreApp.Hub
{
    public class NotificationHub : Hub<IOrderNotification>
    {
        public async Task Subscribe(string topic)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, topic);
        }
        public async Task UnSubscribe(string topic)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, topic);
        }

        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "orders");
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, "orders");
        }
    }
}
