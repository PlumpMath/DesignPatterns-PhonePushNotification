using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    class SubscriptionManager
    {


        public void SubscribePhoneTo(Server server, Abstract_Phone phone, string NewsFeed)
        {
            server.SubscribePhoneToFeed(phone.id, NewsFeed);
        }


    }
}
