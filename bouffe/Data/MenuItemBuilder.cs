//Adapted from 
//https://refactoring.guru/design-patterns/builder/csharp/example

using bouffe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Data
{
    abstract class MenuItemBuilder
    {
        protected IMenuItem menuItem;


        public abstract AMenuItem GetMenuItem();
        
        public abstract void AddName();
        public abstract void AddPrice();
        public abstract void AddShortDesc();
        public abstract void AddImageThumbUrl();
        public abstract void build();

        

    }
}
