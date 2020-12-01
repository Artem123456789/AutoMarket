using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<CarDetail> CarDetails { get; set; }

        public Car()
        {
            CarDetails = new List<CarDetail>();
        }

        public override string ToString() => Name;
    }
}
