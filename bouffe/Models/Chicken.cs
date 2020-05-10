using bouffe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Models
{
    public class Chicken : AMenuItem
    {
        //This constructor is for the builder pattern
        public Chicken(ChickenType chickenType)
        {
            ChickenType = chickenType;
        }

        //This constructor is for object creation via the 'new' operator
        public Chicken()
        {

        }
        //These lines are commented out because originally, this model implemented the 
        //IMenuItem interface. However, since Entity Framework does not support interfaces, 
        //we had to instead implement the abstract class AMenuItem which then implements IMenuItem
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
