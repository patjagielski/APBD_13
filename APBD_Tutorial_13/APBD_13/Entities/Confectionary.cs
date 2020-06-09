using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_13.Entities
{
    public class Confectionary
    {
        public int IdConfectionary { get; set; }
        public string Name { get; set; }
        public float PricePerItem { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Confectionary_Order> Confectionary_Orders { get; set; }
    }
}
