//Adapted from 
//https://exceptionnotfound.net/builder-pattern-in-csharp/

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


        public AMenuItem MenuItem
        {
            get { return (AMenuItem)menuItem; }
        }
        public abstract void AddName();
        public abstract void AddPrice();
        public abstract void AddShortDesc();
        public abstract void AddImageThumbUrl();


    }
}
