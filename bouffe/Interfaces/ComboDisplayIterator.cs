using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class ComboDisplayIterator : IGenericIterator
    {
        private ComboCollection items;
        private int current = 0;
        private int step = 1;

        private bool Done = false;

        public ComboDisplayIterator(ComboCollection items)
        {
            this.items = items;
        }

        //Tell if iteration has completed
        public bool IsDone
        {
            get {

                return Done;

            }
        }

        //Get pizza at current iterator position
        public object Current => items as AMenuItem;

        //Get first Pizza
        public object First()
        {
            return items as AMenuItem;
        }

        //Get next Pizza
        public object Next()
        {
            current += step;
            if (!IsDone)
            {
                Done = true;
                return items as AMenuItem;
            }
            else
            {
                return null;
            }
        }
    }
}
