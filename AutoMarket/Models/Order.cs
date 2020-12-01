using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoMarket.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime Completed { get; set; }
        public string CreatedView => $"{Created.Year}.{Created.Month}.{Created.Day}";
        public string CompletedView => Completed.Year == 1 ? "Не выполнен" : $"{Completed.Year}.{Completed.Month}.{Completed.Day}";
        public decimal Price 
        {   
            get
            {
                decimal value = 0;
                foreach (var item in Items)
                {
                    value += item.CarDetail.Price * item.Quantity;
                }
                return value;
            } 
        }

        public ICollection<Item> Items { get; set; }

        public Order()
        {
            Items = new List<Item>();
            Created = DateTime.Now;
        }
    }
}
