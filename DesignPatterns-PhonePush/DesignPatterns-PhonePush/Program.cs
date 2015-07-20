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
            Phone phone1 = new Phone();
            Phone phone2 = new Phone();

            phone1.Subscribe("Business");
            phone2.Subscribe("Sports");

        }
    }
}
