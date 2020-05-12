//Adapted from https://exceptionnotfound.net/iterator-pattern-in-csharp/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class ComboCollection : AMenuItem, IOrderItemCollection
    {
        private IComboFactory factory;
        private List<IMenuItem> items = new List<IMenuItem>();

        public ComboCollection(IComboFactory factory)
        {
            this.factory = factory;
            this.Build();
        }

        public IGenericIterator CreateIterator()
        {
            return new ComboIterator(this);
        }

        public IGenericIterator CreateDisplayIterator()
        {
            return new ComboDisplayIterator(this);
        }

        public void Build()
        {
            this.items.Add(factory.CreatePizza());
            this.items.Add(factory.CreateWings());
            this.Name = factory.GetType().Name.Replace("Factory",string.Empty);
            this.Price = factory.Price;
            this.ImageThumbUrl = this.factory.ImageThumbUrl;


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
