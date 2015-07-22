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
        
        public void SubscribePhoneToFeed(Abstract_PhoneReference phoneReference, Abstract_NewsFeed NewsFeed)
        {
            SubscriberFactory subscriber = new SubscriberFactory(phoneReference, NewsFeed);
        }


        public string GetAllSubscribedContent(Abstract_PhoneReference phoneReference)
        {
            return phoneReference.subsciptions.GetAllContent();
        }


        public void BulkPushNotifications()
        {
            foreach (Abstract_PhoneReference phoneReference in PhoneList)
            {
                if (phoneReference.subsciptions.IsNewContectAvailable())
                {
                     phoneReference.SendNotification();
                }
            }
        }


        public Abstract_NewsFeed GetNewsFeed(string NewsFeedName)
        {
            Abstract_NewsFeed NewsFeed = null;
            foreach (Abstract_NewsFeed newsFeed in this.NewsFeedList)
            {
                if (newsFeed.FeedName == NewsFeedName)
                {
                    NewsFeed = newsFeed;
                    break;
                }
            }
            return NewsFeed;
        }


        public Abstract_PhoneReference GetPhoneReference(string PhoneID)
        {
            Abstract_PhoneReference phoneRecord = null;
            foreach (Abstract_PhoneReference phoneReference in this.PhoneList)
            {
                if (phoneReference.PhoneID == PhoneID)
                {
                    phoneRecord = phoneReference;
                    break;
                }
            }
            return phoneRecord;
        }

        
        public Abstract_PhoneReference CreateNewPhoneReference(Abstract_Phone phoneObject)
        {
            Abstract_PhoneReference phoneRecord = new Abstract_PhoneReference(phoneObject.id);
            Connection connectionString = new Connection(phoneObject);
            phoneRecord.connection = connectionString;
            PhoneList.Add(phoneRecord);
            return phoneRecord;
        }
    }
}
