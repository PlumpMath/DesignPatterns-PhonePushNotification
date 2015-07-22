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
            NewsFeed_Business BusinessFeed = new NewsFeed_Business();
            Abstract_NewsFeed SportsFeed = new NewsFeed_Sports();
            server.NewsFeedList.Add(BusinessFeed);
            server.NewsFeedList.Add(SportsFeed);

            // Add Starting Articles
            Article BusinessArticle1 = new Article("B1", "Business Article1");
            
            Article SportsArticle1 = new Article("S1", "Sports Article1");
            BusinessFeed.AddNewArticle(BusinessArticle1);
            SportsFeed.AddNewArticle(SportsArticle1);

            // Add Phones
            Abstract_Phone phone1 = new Phone("111");
            Abstract_Phone phone2 = new Phone("222");
            phone1.SubscribeToNewsFeed(server, "Business");
            phone1.SubscribeToNewsFeed(server, "Sports");
            phone2.SubscribeToNewsFeed(server, "Sports");

            // List Current Phone Subscriptions
            Console.WriteLine();
            Console.WriteLine(phone1.id + " is subscribed to " + subscriptionManager.GetCurrentSubscriptionList(server, phone1));
            Console.WriteLine(phone2.id + " is subscribed to " + subscriptionManager.GetCurrentSubscriptionList(server, phone2));

            // Have Business News Add an article and Push a notification (subscription to server-side)
            Console.WriteLine("\nBusiness Newsfeed is about to create 2 new articles.\n- - - \n");
            Article BusinessArticle2 = new Article("B2", "Business Article2");
            BusinessFeed.AddNewArticle(BusinessArticle2);
            Article BusinessArticle3 = new Article("B3", "Business Article3");
            BusinessFeed.AddNewArticle(BusinessArticle3);

            // Have Server push periodic notification (server-side to individual phones)
            Console.WriteLine();
            Console.WriteLine("Server is about to bulk push Notifications.\nAnyone with updates should get buzzed.\n- - -\n");
            server.BulkPushNotifications();

            // Test Recieving the content
            Console.WriteLine();
            Console.WriteLine(phone1.id + " is getting it's content");
            Console.WriteLine(phone1.GetAllSubscribedContent(server));

            // Have Sports News Add an article and Push a notification (subscription to server-side)
            Console.WriteLine("\nSports Newsfeed is about to create 1 new article.\n- - - \n");
            Article SportsArticle2 = new Article("S2", "Sports Article2");
            SportsFeed.AddNewArticle(SportsArticle2);

            // Have Server push periodic notification (server-side to individual phones)
            Console.WriteLine();
            Console.WriteLine("Server is about to bulk push Notifications.\nAnyone with updates should get buzzed.\n- - -\n");
            server.BulkPushNotifications();

            // Test Recieving the content
            Console.WriteLine();
            Console.WriteLine(phone1.id + " is getting it's content");
            Console.WriteLine(phone1.GetAllSubscribedContent(server));
            Console.WriteLine(phone2.id + " is getting it's content");
            Console.WriteLine(phone2.GetAllSubscribedContent(server));
            
            // Test Flags have cleared on GetAllContent()
            Console.WriteLine("Every one has recieved thier content.\nChecking second time to make sure all Notifications have cleared.\nIf nothing shows up after this line, you are good.");
            server.BulkPushNotifications();



            Console.ReadLine();

        }
    }
}
