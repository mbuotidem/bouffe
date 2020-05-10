using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class ComboCollection : IOrderItemCollection
    {
       
        private List<IMenuItem> items = new List<IMenuItem>();

        public IGenericIterator CreateIterator()
        {
            return new MenuItemIterator(this);
        }

        //Get number of menuItems in collection
        public int Count
        {
            get => items.Count;
        }

        //Class Indexer
        public IMenuItem this[int index]
        {
            get => items[index];
            set => items.Add(value);

        }
    }
}
