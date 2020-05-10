using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class VeggiePlainFactory : IComboFactory
    {
        public IMenuItem CreatePizza()
        {
            return new PizzaFactory().CreateMenuItem("Veggie Party", "Veggie");
        }

        public IMenuItem CreateWings()
        {
            return new ChickenFactory().CreateMenuItem("PlainWings");
        }
    }
}
