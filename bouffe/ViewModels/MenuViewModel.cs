using bouffe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.ViewModels
{
    public class MenuViewModel
    {
        //public IOrderItemCollection menuItems = new PizzaCollection();
        //public IGenericIterator menuItems;
        public IEnumerable<IGenericIterator> menuItems;

        //public MenuViewModel(IOrderItemCollection menuItems)
        //{
        //    this.menuItems = menuItems;
        //}
        //public MenuViewModel(IGenericIterator menuItems)
        //{
        //    this.menuItems = menuItems;
        //}

        public MenuViewModel(IEnumerable<IGenericIterator> menuItems)
        {
            this.menuItems = menuItems;
        }
    }
}
