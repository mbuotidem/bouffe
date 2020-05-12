//Adapted from Head First Design Patterns by Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class HawaiianHotFactory : IComboFactory
    {
        public decimal Price { get; set; }

        public string Image { get; set; }

        public string ImageThumbUrl { get; set; }

        public HawaiianHotFactory()
        {
            this.Price = 7;
            this.ImageThumbUrl = "/images/HawaiianHot.jpg";
        }
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
