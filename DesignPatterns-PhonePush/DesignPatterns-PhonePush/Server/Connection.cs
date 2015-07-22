using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public class Connection : IConnection
    {
        protected Abstract_Phone phone;


        public Connection(Abstract_Phone phone)
        {
            this.phone = phone;
        }

        public void Notify(string message)
        {
            // Pretend there is a bunch of logic here to create the connection
            // In reality it just called the phone's notification method

            this.phone.Notification(message);

        }
    }
}
