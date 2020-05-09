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
            Chicken menuItem = null;

            switch (itemName)
            {
                case "Hotwings":
                    HotWingsBuilder builder = new HotWingsBuilder();
                    builder.build();
                    menuItem = (Chicken)builder.MenuItem;
                    break;

                case "PlainWings":
                    menuItem = (Chicken)new ChickenFactory().CreateMenuItem(itemName);
                    break;

            }

            //throw new NotImplementedException();
            return menuItem;
        }
    }
}
