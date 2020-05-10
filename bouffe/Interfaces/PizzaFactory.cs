//Adapted from
//https://refactoring.guru/design-patterns/factory-method/csharp/example
using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class PizzaFactory : IMenuItemFactory
    {
        public AMenuItem CreateMenuItem(string itemName, string itemType = "default")
        {
            var pizzaType = new PizzaType();

            switch (itemType)
            {
                case "Hawaiian":
                    pizzaType = new PizzaType { PizzaTypeId = 1, PizzaTypeName = "Hawaiian", Description = "Tropical" };
                    break;

                case "Pepperoni":
                    pizzaType = new PizzaType { PizzaTypeId = 2, PizzaTypeName = "Pepperoni", Description = "Pepperish" };
                    break;

                case "Veggie":
                    pizzaType = new PizzaType { PizzaTypeId = 3, PizzaTypeName = "Veggie", Description = "Herbivores" };
                    break;
            }

            
            Pizza menuItem = new Pizza();

            switch (itemName)
            {
                case "Hawaiian Delight":
                    menuItem = new Pizza { Id = pizzaType.PizzaTypeId, Name = "Hawaiian Delight", Price = 5.99M, ShortDesc = "Ham and Pineapple", PizzaType = pizzaType, ImageThumbUrl = "/images/hawaiian.jpg" };
                    break;
                case "Pepperoni Mashup":
                    menuItem = new Pizza { Id = pizzaType.PizzaTypeId, Name = "Pepperoni Mashup", Price = 5.99M, ShortDesc = "Cheese", PizzaType = pizzaType, ImageThumbUrl = "/images/pepperoni.jpg" };
                    break;
                case "Veggie Party":
                    menuItem = new Pizza { Id = pizzaType.PizzaTypeId, Name = "Veggie Party", Price = 5.99M, ShortDesc = "Vegetables", PizzaType = pizzaType, ImageThumbUrl = "/images/veggie.jpg" };
                    break;

            }

            
            return menuItem;
        }
    }
}
