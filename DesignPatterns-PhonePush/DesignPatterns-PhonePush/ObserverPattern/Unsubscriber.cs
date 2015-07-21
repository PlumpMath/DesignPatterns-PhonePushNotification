using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    class Unsubscriber : IDisposable
    {
        private List<IObserver<bool>> observerList;
        private IObserver<bool> subscriber;


        public Unsubscriber(List<IObserver<bool>> observerList, IObserver<bool> subscriber)
        {
            this.observerList = observerList;
            this.subscriber = subscriber;
        }

        public void Dispose()
        {
            if (!(subscriber == null)) observerList.Remove(subscriber);
        }
        
    }
}
