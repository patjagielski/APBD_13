using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_13.Entities
{
    public class Confectionary_Order
    {
        public int IdConfection { get; set; }
        public int IdOrder { get; set; }
        public int Quantity { get; set; }
        public string Notes { get; set; }
        public virtual Confectionary Confectionary { get; set; }
        public virtual Order Order { get; set; }
        public virtual ICollection<Confectionary_Order> Confectionary_Orders { get; set; }
    }
}
