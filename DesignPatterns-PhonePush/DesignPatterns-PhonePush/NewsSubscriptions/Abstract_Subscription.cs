using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public abstract class Abstract_Subscription: ISubscription, IObserver<bool>
    {
        // Decorator Design Pattern (Onion Layers)
        protected Abstract_Subscription OuterLayer;
        protected Abstract_Subscription InnerLayer;
        protected Abstract_NewsFeed NewsFeed;
        protected string NewsFeedName = "";
        protected bool UpdateAvailable;
        protected IDisposable unsubscriber;

        



        public Abstract_Subscription(Abstract_Subscription outerLayer, Abstract_NewsFeed NewsFeedObject)
        {
            this.OuterLayer = outerLayer;
            this.UpdateAvailable = false;
            this.NewsFeed = NewsFeedObject;
        }

        public virtual string GetSubscriptions()
        {
            if (this.OuterLayer != null)
            {
                return (this.OuterLayer.GetSubscriptions() + this.NewsFeedName + " "); 
            }
            else
            {
                return (this.NewsFeedName + " ");
            } 
        }


        public bool IsNewContectAvailable()
        {
            if (this.OuterLayer != null)
            {
                return (this.OuterLayer.IsNewContectAvailable() || UpdateAvailable); 
            }
            else
            {
                return (UpdateAvailable);
            } 
        }

            
        public string GetAllContent()
        {
            this.UpdateAvailable = false; // clear the notification flag once the content has been recieved the first time.
            if (this.OuterLayer != null)
            {
                return (this.OuterLayer.GetAllContent() + this.NewsFeed.GetAllContent());
            }
            else
            {
                return (this.NewsFeed.GetAllContent());
            } 
        }

        public virtual void Subscribe(IObservable<bool> provider)
        {
            this.unsubscriber = provider.Subscribe(this);
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }


        public virtual void OnNext(bool NotificationAvailable)
        {
            if (NotificationAvailable)
            {
                Console.WriteLine("There is a new update available in " + this.NewsFeedName);
                this.UpdateAvailable = true;
            }

        }

        public virtual void OnCompleted()
        {
            Console.WriteLine("Additional News Feeds will not be processed from this");
        }

        public virtual void OnError(Exception error)
        {
            // Do nothing.
        }
    }
}
