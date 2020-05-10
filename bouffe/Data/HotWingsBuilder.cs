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
    class HotWingsBuilder : MenuItemBuilder
    {
        
        public HotWingsBuilder()
        {
            ChickenType chickenType = new ChickenType { ChickenTypeId = 1, ChickenTypeName = "Wings", Description = "Delicious" };
            menuItem = new Chicken(chickenType);
            menuItem.Id = chickenType.ChickenTypeId;
        }

        public override void AddImageThumbUrl()
        {
            menuItem.ImageThumbUrl = "/images/hotwings.jpg";
        }

        public override void AddName()
        {
            menuItem.Name = "HotWings";
        }

        public override void AddPrice()
        {
            menuItem.Price = 5.99M;
        }

        public override void AddShortDesc()
        {
            menuItem.ShortDesc = "They're hot!";
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
            this.menuItem = new Chicken();
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