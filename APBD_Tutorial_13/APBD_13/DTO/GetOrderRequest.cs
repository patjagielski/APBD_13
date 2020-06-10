using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_13
{
    public class GetOrderRequest
    {
        public int IdOrder { get; set; }
        public string DateAccepted { get; set; }
        public string DateFinished { get; set; }
        public int IdConfectionary { get; set; }
        public int QuantityOfConfectionary { get; set; }

    }
}
