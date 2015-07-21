using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    class Program
    {
        static void Main(string[] args)
        {
            Server server = new Server();
            SubscriptionManager subscriptionManager = new SubscriptionManager();

            // Add news feeds
            NewsFeed_Business newsFeed1 = new NewsFeed_Business();
            Abstract_NewsFeed newsFeed2 = new NewsFeed_Sports();
            server.NewsFeedList.Add(newsFeed1);
            server.NewsFeedList.Add(newsFeed2);


            Abstract_Phone phone1 = new Phone("111");
            Abstract_Phone phone2 = new Phone("222");

            subscriptionManager.SubscribePhoneTo(server, phone1, "Business");
            subscriptionManager.SubscribePhoneTo(server, phone1, "Sports");
            subscriptionManager.SubscribePhoneTo(server, phone1, "Sports");
            subscriptionManager.SubscribePhoneTo(server, phone2, "Sports");

            newsFeed2.Notify_NewsUpdate();

            Console.ReadLine();

        }
    }
}
