//Adapted from https://exceptionnotfound.net/iterator-pattern-in-csharp/
using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class ChickenIterator : IGenericIterator
    {
        private ChickenCollection chickens;
        private int current = 0;
        private int step = 1;

        public ChickenIterator(ChickenCollection chickens)
        {
            this.chickens = chickens;
        }

        //Tell if iteration has completed
        public bool IsDone
        {
            get => current >= chickens.Count;
        }

        //Get chicken at current iterator position
        public object Current => chickens[current] as Chicken;

        //Get first Chicken
        public object First()
        {
            current = 0;
            return chickens[current] as Chicken;
        }

        //Get next Chicken
        public object Next()
        {
            current += step;
            if (!IsDone)
            {
                return chickens[current] as Chicken;
            }
            else
            {
                return null;
            }
        }
    }

    
}
