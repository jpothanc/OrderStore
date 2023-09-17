using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreApp.Services
{
    public interface IItemObserver<T> 
    {
        IDisposable Subscribe(Action<T> action);
        void UnSubscribe(IDisposable disposable);
        void Notify(T item);
        
    }
    public class ItemObserver<T> : IItemObserver<T>
    {
        private Subject<T> _subject;
        private IObservable<T> _observable;
        public ItemObserver()
        {
            _subject = new Subject<T>();
            _observable = _subject.AsObservable();
        }

       public IDisposable Subscribe(Action<T> action)
        {
            return _observable.Subscribe(action);
        }

        public void Notify(T item)
        {
            _subject.OnNext(item);
        }

        public void UnSubscribe(IDisposable disposable)
        {
            if (disposable != null)
            {
                disposable?.Dispose();
            }
        }
      
    }
}
