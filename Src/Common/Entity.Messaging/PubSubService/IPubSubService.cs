using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Messaging
{
    public interface IPubSubService
    {
        void Subscribe(ISubscriberService subscriber);
        void Publish(IEvent Event);
    }
}
