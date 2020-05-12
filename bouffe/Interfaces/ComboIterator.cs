using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class ComboIterator : IGenericIterator
    {
        private ComboCollection items;
        private int current = 0;
        private int step = 1;

        public ComboIterator(ComboCollection items)
        {
            this.items = items;
        }

        //Tell if iteration has completed
        public bool IsDone
        {
            get => current >= items.Count;
        }

        //Get pizza at current iterator position
        public object Current => items[current] as AMenuItem;

        //Get first Pizza
        public object First()
        {
            current = 0;
            return items[current] as AMenuItem;
        }

        //Get next Pizza
        public object Next()
        {
            current += step;
            if (!IsDone)
            {
                return items[current] as AMenuItem;
            }
            else
            {
                return null;
            }
        }
    }
}
