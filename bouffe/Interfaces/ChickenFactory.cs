//Adapted from
//https://refactoring.guru/design-patterns/factory-method/csharp/example
using bouffe.Data;
using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class ChickenFactory : IMenuItemFactory
    {
        public AMenuItem CreateMenuItem(string itemName)
        {
            var chickenType = new ChickenType { ChickenTypeId = 1, ChickenTypeName = "Wings", Description = "Delicious" };
            Chicken menuItem = null;

            switch (itemName)
            {
                //case "Hotwings":
                //    HotWingsBuilder builder = new HotWingsBuilder();
                //    builder.build();
                //    menuItem = (Chicken)builder.MenuItem;
                //    break;

                case "Hotwings":
                    menuItem = new Chicken { Id = 1, Name = "Hotwings", Price = 5.99M, ShortDesc = "They're hot!", ChickenType = chickenType, ImageThumbUrl = "/images/hotwings.jpg" };
                    break;
                case "PlainWings":
                    menuItem = new Chicken { Id = 1, Name = "PlainWings", Price = 5.99M, ShortDesc = "They're plain!", ChickenType = chickenType, ImageThumbUrl = "/images/plainwings.jpg" };
                    break;

            }

            //throw new NotImplementedException();
            return menuItem;
        }
    }
}
