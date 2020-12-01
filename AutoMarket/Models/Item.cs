using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int CarDetailId { get; set; }
        public CarDetail CarDetail { get; set; }
        public int Quantity { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}
