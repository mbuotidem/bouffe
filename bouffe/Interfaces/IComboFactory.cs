//Adapted from Head First Design Patterns by Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public interface IComboFactory
    {
        IMenuItem CreatePizza();

        IMenuItem CreateWings();
    }
}
