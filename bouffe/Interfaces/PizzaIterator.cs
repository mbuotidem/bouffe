//Adapted from https://exceptionnotfound.net/iterator-pattern-in-csharp/
using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class PizzaIterator : IGenericIterator
    {
        private PizzaCollection pizzas;
        private int current = 0;
        private int step = 1;

        public PizzaIterator(PizzaCollection pizzas)
        {
            this.pizzas = pizzas;
        }

        //Tell if iteration has completed
        public bool IsDone 
        {
            get => current >= pizzas.Count; 
        }

        //Get pizza at current iterator position
        public object Current => pizzas[current] as Pizza;

        //Get first Pizza
        public object First()
        {
            current = 0;
            return pizzas[current] as Pizza;
        }

        //Get next Pizza
        public object Next()
        {
            current += step;
            if (!IsDone)
            {
                return pizzas[current] as Pizza;
            }
            else
            {
                return null;
            }
        }
    }
}
