//Adapted from
//https://refactoring.guru/design-patterns/factory-method/csharp/example
using bouffe.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public interface IMenuItemFactory
    {
        public abstract AMenuItem CreateMenuItem(String itemName);
    }
}
