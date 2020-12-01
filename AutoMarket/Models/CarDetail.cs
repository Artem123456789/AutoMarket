using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models
{
    public class CarDetail
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string DetailCar => $"{Name} ({Car.Name})";
        
        public int CarId { get; set; }
        public Car Car { get; set; }
        public ICollection<Item> Items { get; set; }

        public CarDetail()
        {
            Items = new List<Item>();
        }

        public override string ToString() => Name;
    }
}
