using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_13.Entities
{
    public class Order
    {
        public int IdOrder { get; set; }
        public string DateAccepted { get; set; }
        public string DateFinished { get; set; }
        public string Notes { get; set; }
        public int IdClient { get; set; }
        public int IdEmployee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual ICollection<Confectionary_Order> Confectionary_Order { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
