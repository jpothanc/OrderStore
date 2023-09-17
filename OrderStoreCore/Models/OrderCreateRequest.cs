using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderStoreCore.Models
{
    public class OrderCreateRequest
    {
        public String Product { get; set; }
        public String Price { get; set; }
        public int Size { get; set; }
        public String Acronym { get; set; }
        public String Account { get; set; }
        public String Entity { get; set; }
    }
}
