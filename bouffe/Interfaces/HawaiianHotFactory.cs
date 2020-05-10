using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class HawaiianHotFactory : IComboFactory
    {
        public IMenuItem CreatePizza()
        {
            return new PizzaFactory().CreateMenuItem("Hawaiian Delight", "Hawaiian");
        }

        public IMenuItem CreateWings()
        {
            return new ChickenFactory().CreateMenuItem("HotWings");
        }


    }
}
