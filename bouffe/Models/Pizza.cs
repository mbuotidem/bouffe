using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Models
{
    public class Pizza
    {
        public int PizzaId { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string LongDesc { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageThumbUrl { get; set; }
        public bool IsPizzaOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int PizzaTypeId { get; set; }
        public PizzaType PizzaType { get; set; }
    }
}
