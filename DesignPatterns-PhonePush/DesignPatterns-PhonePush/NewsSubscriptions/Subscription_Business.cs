﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public class Subscription_Business : Abstract_Subscription
    {
        public Subscription_Business(Abstract_Subscription subscription, Abstract_NewsFeed NewsFeedObject) : base(subscription, NewsFeedObject)
        { 
            this.NewsFeedName = "Business";
        }
    }
}
