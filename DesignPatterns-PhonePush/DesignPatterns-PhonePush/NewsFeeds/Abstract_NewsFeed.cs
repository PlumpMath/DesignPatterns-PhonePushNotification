using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public class Abstract_NewsFeed : INewsFeed, IObservable<bool>
    {
        public string FeedName;
        private List<IObserver<bool>> observerList = new List<IObserver<bool>>();
        private List<Article> articleList = new List<Article>();

        public IDisposable Subscribe(IObserver<bool> subscriber)
        {
            if (!this.observerList.Contains(subscriber))
                this.observerList.Add(subscriber);

            return new Unsubscriber(observerList, subscriber);
        }

        public void Notify_NewsUpdate()
        {
            foreach (var subscriber in this.observerList)
            {
                subscriber.OnNext(true);
            }
        }



    }
}
