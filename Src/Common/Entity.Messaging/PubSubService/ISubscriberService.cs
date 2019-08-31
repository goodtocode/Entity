using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Messaging
{
    
    public interface ISubscriberService
    {
        IEnumerable<Type> EventTypes { get; }
        Task HandleEvent(IEvent Event);
    }    
}
