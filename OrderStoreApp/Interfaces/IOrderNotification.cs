namespace OrderStoreApp.Interfaces
{
    public interface IOrderNotification
    {
        Task Notify(string response);
    }
}
