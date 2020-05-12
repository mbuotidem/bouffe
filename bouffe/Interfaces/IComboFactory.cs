//Adapted from Head First Design Patterns by Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public interface IComboFactory
    {
        public decimal Price { get; set; }

        public string Image { get; set; }

        public string ImageThumbUrl { get; set; }
        IMenuItem CreatePizza();

        IMenuItem CreateWings();
    }
}
