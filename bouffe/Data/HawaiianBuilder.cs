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
            menuItem = new Pizza();
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
            throw new NotImplementedException();
        }

        public override AMenuItem GetMenuItem()
        {
            throw new NotImplementedException();
        }
    }
}
