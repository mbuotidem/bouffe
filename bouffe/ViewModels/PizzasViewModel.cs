using bouffe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.ViewModels
{
    public class PizzasViewModel
    {
        public IEnumerable<Pizza> pizzas = Enumerable.Empty<Pizza>();

        public PizzasViewModel(IEnumerable<Pizza> pizzas)
        {
            this.pizzas = pizzas;
        }
    }
}
