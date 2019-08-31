using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Messaging
{
   
    public interface ILoggerListener : ISubscriberService
    { }

    public class LoggerListener : ILoggerListener
    {
        public IEnumerable<Type> EventTypes
        {
            get
            {
                return new List<Type>()
                {
                    typeof(EnrollmentPromotionEvent)
                };
            }
        }
        public async Task HandleEvent(IEvent Event)
        {
            var a = 23; // Log something
        }
    }

    public class EnrollmentPromotionEvent : IEvent
    {
    }

    public class EnrollmentCreationEvent : IEvent
    {
    }

}
