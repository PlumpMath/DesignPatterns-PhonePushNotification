using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    class SubscriberFactory
    {
        public SubscriberFactory (Abstract_PhoneReference phoneReference,  Abstract_NewsFeed NewsFeedObject)
        {
            IObservable<bool> NewsFeedObserver = (IObservable<bool>)NewsFeedObject;
            switch (NewsFeedObject.FeedName)
            {
                case "Business":
                    {
                        phoneReference.subsciptions = new Subscription_Business(phoneReference.subsciptions, NewsFeedObject);
                        phoneReference.subsciptions.Subscribe(NewsFeedObserver);
                        break;
                    }
                case "Sports":
                    {
                        phoneReference.subsciptions = new Subscription_Sports(phoneReference.subsciptions, NewsFeedObject);
                        phoneReference.subsciptions.Subscribe(NewsFeedObserver);
                        break;
                    }
            }
        }
    }
}
