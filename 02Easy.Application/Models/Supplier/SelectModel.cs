using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Application.Models.Supplier
{
    public class SelectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tel { get; set; }

        public string Address { get; set; }
        public bool DeliveryStatus { get; set; }
        public int BusinessStatus { get; set; } 
    }
}
