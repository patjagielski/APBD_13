using APBD_13.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_13.DTO
{
    public class AddOrderRequest
    {
        public string DateAccepted { get; set; }
        public string Notes { get; set; }
        public ICollection<CustomConfectionary> Confectionery { get; set; }
        
    }
}
