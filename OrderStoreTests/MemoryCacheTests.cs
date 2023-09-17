using OrderStoreApp.Ports;
using OrderStoreAdaptors.Cache;
using Xunit;
using OrderStoreTests.Internal;

namespace OrderStoreTests
{
    public class MemoryCacheTests
    {
        [Fact(DisplayName = "The Add method should Order to Cache")]
        public void Add_ShouldAddOrderToCache()
        {
            ICache cache = new InMemoryCache();

            var order = TestHelper.GetOrder();
            cache.Add(order);
            var cacheOrder = cache.GetOrder(order.Orderid);
            Assert.NotNull(cacheOrder);
            Assert.Equal(order.Orderid, order.Orderid);

        }
    }
}