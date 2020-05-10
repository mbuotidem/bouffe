using bouffe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Models
{
    public class Pizza : AMenuItem
    {
        //This constructor is for the builder pattern
        public Pizza(PizzaType pizzaType)
        {
            PizzaType = pizzaType;
        }

        //This constructor is for object creation via the 'new' operator
        public Pizza()
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
        //public bool IsPizzaOfTheWeek { get; set; }
        //public bool InStock { get; set; }

        //EF Core Entities and navigational property
        public int PizzaTypeId { get; set; }
        public PizzaType PizzaType { get; set; }
    }
}
