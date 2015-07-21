using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public class Server
    {
        public List<Abstract_PhoneReference> PhoneList = new List<Abstract_PhoneReference>();
        public List<Abstract_NewsFeed> NewsFeedList = new List<Abstract_NewsFeed>();


        public void SubscribePhoneToFeed(string PhoneID, string NewsFeedName)
        {
            //
            // Check if the NewsFeed Exists
            // 
            Abstract_NewsFeed NewsFeed = null;
            foreach (Abstract_NewsFeed newsFeed in this.NewsFeedList)
            {
                if(newsFeed.FeedName == NewsFeedName)
                {
                    NewsFeed = newsFeed;
                    break;
                }
            }


            if (NewsFeed != null)
            {
                //
                // Check if phone is already in the phone list
                //
                Abstract_PhoneReference phone = null;
                foreach (Abstract_PhoneReference PhoneReference in PhoneList)
                {
                    if (PhoneReference.PhoneID == PhoneID)
                    {
                        phone = PhoneReference;
                        break;
                    }
                }

                //
                // I phone exists, update it.
                //
                if (phone == null)
                {
                    phone = new Abstract_PhoneReference(PhoneID);
                    PhoneList.Add(phone);
                }
                SubscriberFactory subscriber = new SubscriberFactory(phone, NewsFeedName, NewsFeed);
                Console.WriteLine(phone.PhoneID + " is subscribed to: " + phone.GetSubscriptions());
            }
        }

    }
}
