using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    class SubscriptionManager
    {
        public void SubscribePhoneToServer(Server server, Abstract_Phone phone, string NewsFeedName)
        {
            Abstract_NewsFeed NewsFeed = server.GetNewsFeed(NewsFeedName);
            if (NewsFeed != null)
            {
                Abstract_PhoneReference PhoneReference = server.GetPhoneReference(phone.id);
                if (PhoneReference == null)
                {
                    PhoneReference = server.CreateNewPhoneReference(phone);
                }
                server.SubscribePhoneToFeed(PhoneReference, NewsFeed);
            }
            else
            {
                phone.Notification("A " + NewsFeedName + " newsfeed does not exist.");
            }
        }

        public string GetAllSubscribedContent(Server server, Abstract_Phone phone)
        {
            Abstract_PhoneReference PhoneReference = server.GetPhoneReference(phone.id);
            if (PhoneReference != null)
            {
                return server.GetAllSubscribedContent(PhoneReference);
            }
            else
            {
                return "This phone is not currently subscribed to this server.";
            }
        }

        public string GetCurrentSubscriptionList(Server server, Abstract_Phone phone)
        {
            Abstract_PhoneReference PhoneReference = server.GetPhoneReference(phone.id);
            if (PhoneReference != null)
            {
                return PhoneReference.subsciptions.GetSubscriptions();
            }
            else
            {
                return "This phone is not currently subscribed to this server.";
            }
        }

    }
}
