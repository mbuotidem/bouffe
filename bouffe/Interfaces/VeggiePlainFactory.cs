//Adapted from Head First Design Patterns by Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Interfaces
{
    public class VeggiePlainFactory : IComboFactory
    {
        public decimal Price { get; set; }

        public string Image { get; set; }

        public string ImageThumbUrl { get; set; }

        public VeggiePlainFactory()
        {
            this.Price = 7;
            this.ImageThumbUrl = "/images/VeggiePlain.jpg";
        }

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
