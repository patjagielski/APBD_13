using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_13.Entities
{
    public class Customer
    {
        public int IdClient { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
