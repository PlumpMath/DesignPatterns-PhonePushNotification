using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns_PhonePush
{
    public interface ISubscription
    {
        bool IsNewContectAvailable();
        string GetAllContent();
        void AddPhone();

    }
}
