using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    class SubscriberFactory
    {
        public SubscriberFactory (Abstract_PhoneReference phoneReference, string FeedName, IObservable<bool> NewsFeed)
        {
            switch (FeedName)
            {
                case "Business":
                    {
                        phoneReference.subsciptions = new Subscription_Business(phoneReference.subsciptions);
                        phoneReference.subsciptions.Subscribe(NewsFeed);
                        break;
                    }
                case "Sports":
                    {
                        phoneReference.subsciptions = new Subscription_Sports(phoneReference.subsciptions);
                        phoneReference.subsciptions.Subscribe(NewsFeed);
                        break;
                    }
            }
        }
    }
}
