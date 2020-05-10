//Adapted from
//https://refactoring.guru/design-patterns/factory-method/csharp/example
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class PizzaFactory : IMenuItemFactory
    {
        public AMenuItem CreateMenuItem(string itemName)
        {
            throw new NotImplementedException();
        }
    }
}
