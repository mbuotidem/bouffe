//Adapted from 
//https://refactoring.guru/design-patterns/builder/csharp/example

using bouffe.Interfaces;
using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Data
{
    class HawaiianBuilder : MenuItemBuilder
    {
        public HawaiianBuilder()
        {
            PizzaType pizzaType = new PizzaType { PizzaTypeId = 1, PizzaTypeName = "Hawaiian", Description = "Tropical" };
            menuItem = new Pizza(pizzaType);
            menuItem.Id = pizzaType.PizzaTypeId;
        }
        public override void AddImageThumbUrl()
        {
            menuItem.ImageThumbUrl = "/images/hawaiian.jpg";
        }

        public override void AddName()
        {
            menuItem.Name = "Hawaiian Delight";
        }

        public override void AddPrice()
        {
            menuItem.Price = 5.99M;
        }

        public override void AddShortDesc()
        {
            menuItem.ShortDesc = "Ham and Pineapple";
        }

        public override void build()
        {
            this.AddImageThumbUrl();
            this.AddName();
            this.AddPrice();
            this.AddShortDesc();
        }
        public void Reset()
        {
            this.menuItem = new Pizza();
        }

        public override AMenuItem GetMenuItem()
        {
            this.build();

            AMenuItem result = (AMenuItem)this.menuItem;

            this.Reset();

            return result;
        }
    }
}
