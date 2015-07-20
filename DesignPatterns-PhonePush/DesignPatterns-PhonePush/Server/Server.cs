using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public class Server
    {
        List<Abstract_PhoneReference> PhoneList;
        List<INewsFeed> NewFeedList;

        public Server()
        {

        }

        public void SubscribePhoneToFeed(string PhoneID, string NewsFeed)
        {
            // Check if phone is already in the phone list
            Abstract_PhoneReference phone = null;
            foreach (Abstract_PhoneReference PhoneReference in PhoneList)
            {
                if (PhoneReference.PhoneID == PhoneID)
                {
                    phone = PhoneReference;
                    break;
                }
            }

            if (phone != null)
            {
                Abstract_Subscription subscription = null;
                
            }


        }

    }
}
