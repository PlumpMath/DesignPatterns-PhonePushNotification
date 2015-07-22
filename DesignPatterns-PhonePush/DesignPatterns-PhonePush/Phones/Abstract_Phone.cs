using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public class Abstract_Phone
    {
        public string id;
        SubscriptionManager subscriptionManager = new SubscriptionManager();
        
        public Abstract_Phone(string id)
        {
            this.id = id;
        }


        public void Notification(string message)
        {
            Console.WriteLine("Phone number " + this.id + " buzzes: " + message);
        }


        public void SubscribeToNewsFeed(Server server, string NewsFeedName)
        {
            
            this.subscriptionManager.SubscribePhoneToServer(server, this, NewsFeedName);
        }


        public string GetAllSubscribedContent(Server server)
        {
            return this.subscriptionManager.GetAllSubscribedContent(server, this);
        }

    }
}
