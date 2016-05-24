using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Easy.Domain.Event;

namespace Easy.Application.Application.Supplier.AddDomainEvents
{
    public class AddDomainEvent:IDomainEvent
    {
        public AddDomainEvent()
        {
        }

        public AddDomainEvent(Int32 id,string name,string tel,string address,DateTime creatDate)
        {
            this.Id = id;
            this.Name = name;
            this.Tel = tel;
            this.Address = address;
            this.OccurredOn = creatDate;
        }


        public Int32 Id { get; private set; }

        public string Name { get; private set; }

        public string Tel { get; private set; }

        public string Address { get; private set; }

        

        public DateTime OccurredOn
        {
            get;
            private set; 
        }
    }
}
