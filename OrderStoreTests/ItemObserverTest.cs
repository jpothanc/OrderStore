using OrderStoreApp.Services;
using OrderStoreCore.Models;
using System;
using Xunit;

namespace OrderStoreTests.Internal
{
    public class ItemObserverTest : TestBase
    {

        //private ItemObserver<OrderEvent> TestObserver(Action<OrderEvent> action)
        //{
        //    ItemObserver<OrderEvent> observer = new();
        //    observer.Subscribe(action);
        //    return observer;
        //}

        //[Fact]
        //public void ObserveOnItemShouldBeSuccessful()
        //{
        //    OrderEvent? response = null;
        //    var observer = TestObserver(x =>
        //    {
        //        response = x;
        //    });
        //    observer.Notify(TestHelper.GetNewOrderEvent());
        //    Delay();
        //    Assert.NotNull(response);
        //}

        //[Fact]
        //public void ObserveOnItemShouldBeSuccessfulForMultipleSubscriptions()
        //{
        //    ItemObserver<OrderEvent> observer = new();
        //    OrderEvent? response1 = null;
        //    OrderEvent? response2 = null;
        //    observer.Subscribe(x =>
        //    {
        //        response1 = x;
        //    });
        //    observer.Subscribe(x =>
        //    {
        //        response2 = x;
        //    });
        //    observer.Notify(TestHelper.GetNewOrderEvent());
        //    Delay();
        //    Assert.NotNull(response1);
        //    Assert.NotNull(response2);

        //}

        //[Fact]
        //public void ObserveOnItemShouldFailIfNotSubscribed()
        //{
        //    ItemObserver<OrderEvent> observer = new();
        //    OrderEvent? response = null;
        //    observer.Notify(TestHelper.GetNewOrderEvent());
        //    Delay();
        //    Assert.Null(response);
        //}

        //[Fact]
        //public void ObserveOnItemShouldFailAfterUnSubscription()
        //{
        //    ItemObserver<OrderEvent> observer = new();
        //    OrderEvent? response = null;
        //    var disposable = observer.Subscribe(x =>
        //    {
        //        response = x;
        //    });
        //    observer.UnSubscribe(disposable);

        //    observer.Notify(TestHelper.GetNewOrderEvent());
        //    Delay();
        //    Assert.Null(response);
        //}
        //[Fact]
        //public void ObserveOnItemShouldFailAfterUnSubscriptionForMultipleSubscribers()
        //{
        //    ItemObserver<OrderEvent> observer = new();
        //    OrderEvent? response1 = null;
        //    OrderEvent? response2 = null;
        //    var disposable1 = observer.Subscribe(x =>
        //   {
        //       response1 = x;
        //   });
        //    var disposable2 = observer.Subscribe(x =>
        //    {
        //        response2 = x;
        //    });

        //    disposable1.Dispose();
        //    disposable2.Dispose();


        //    observer.Notify(TestHelper.GetNewOrderEvent());
        //    Delay();
        //    Assert.Null(response1);
        //    Assert.Null(response2);

        //}


        //[Fact]
        //public void ObserveOnItemShouldNotFailAfterMultipleUnSubscription()
        //{
        //    ItemObserver<OrderEvent> observer = new();
        //    OrderEvent? response = null;
        //    var disposable = observer.Subscribe(x =>
        //    {
        //        response = x;
        //    });
        //    observer.UnSubscribe(disposable);
        //    observer.UnSubscribe(disposable);

        //    observer.Notify(TestHelper.GetNewOrderEvent());
        //    Delay();
        //    Assert.Null(response);
        //}

    }
}
