using bouffe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Models
{
    public class Chicken : AMenuItem
    {
        //public int Id { get; set; }
        //public string Name { get; set; }
        //public string ShortDesc { get; set; }
        //public string LongDesc { get; set; }
        //public decimal Price { get; set; }
        //public string ImageUrl { get; set; }
        //public string ImageThumbUrl { get; set; }
        //public bool InStock { get; set; }
        public int ChickenTypeId { get; set; }
        public ChickenType ChickenType { get; set; }
    }
}
