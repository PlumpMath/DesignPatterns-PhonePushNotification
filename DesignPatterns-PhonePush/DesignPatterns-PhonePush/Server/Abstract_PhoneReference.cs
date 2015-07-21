using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public class Abstract_PhoneReference : IPhoneReference
    {
        public IConnection connection;
        public Abstract_Subscription subsciptions;
        protected string id;

        public Abstract_PhoneReference(string id)
        {
            this.id = id;

        }

        public string GetSubscriptions()
        {
            return subsciptions.GetSubscriptions();
        }



        public string PhoneID
        {
            get { return this.id; }
        }

        public void SendNotification(IConnection connection)
        {

        }

    }
}
