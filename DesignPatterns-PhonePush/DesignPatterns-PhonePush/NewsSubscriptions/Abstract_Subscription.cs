using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public abstract class Abstract_Subscription: ISubscription
    {
        // Decorator Design Pattern (Onion Layers)
        ISubscription OuterLayer;
        ISubscription InnerLayer;



        public Abstract_Subscription(ISubscription outerLayer)
        {
            this.OuterLayer = outerLayer;     
        }


        public bool IsNewContectAvailable()
        {

            return true;
        }

            
        public string GetAllContent()
        {

            return "";
        }

        public void AddPhone()
        {



        }
    }
}
