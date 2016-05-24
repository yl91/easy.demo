using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Public.MyLog;
using Newtonsoft.Json;

namespace Easy.Application.Application.Supplier.AddDomainEvents
{
    class AddSubscriber:Easy.Domain.Event.IDomainEventSubscriber<AddDomainEvent>
    {
        public void HandleEvent(AddDomainEvent aDomainEvent)
        {
            LogManager.Info("==test==",JsonConvert.SerializeObject(aDomainEvent));
        }

        public Type SuscribedToEventType
        {
            get { return typeof (AddDomainEvent); }
        }
    }
}
