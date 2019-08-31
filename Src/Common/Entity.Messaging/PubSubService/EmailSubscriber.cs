﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoodToCode.Entity.Messaging
{
    public interface IEmailListener : ISubscriberService
    { }

    public class EmailListener : IEmailListener
    {


        public IEnumerable<Type> EventTypes
        {
            get
            {
                return new List<Type>()
                {
                    typeof(EnrollmentPromotionEvent),
                    typeof(EnrollmentCreationEvent)
                };
            }
        }
        public async Task HandleEvent(IEvent Event)
        {
            var a = 23; // Email something
        }
    }
}