using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bouffe.Data;
using bouffe.Interfaces;
using bouffe.Models;
using bouffe.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bouffe.Controllers
{
    public class HomeController : Controller
    {
        IEnumerable<PizzaType> pizzaTypes = Enumerable.Empty<PizzaType>();
        IEnumerable<IMenuItem> pizzas = Enumerable.Empty<Pizza>();
        IEnumerable<ChickenType> chickenTypes = Enumerable.Empty<ChickenType>();
        IEnumerable<IMenuItem> chickens = Enumerable.Empty<Chicken>();
        List<IGenericIterator> combos = new List<IGenericIterator>();

        public HomeController()
        {
            
            pizzas = new List<IMenuItem>
            {
                new PizzaFactory().CreateMenuItem("Hawaiian Delight", "Hawaiian"),
                new PizzaFactory().CreateMenuItem("Pepperoni Mashup", "Pepperoni"),
                new PizzaFactory().CreateMenuItem("Veggie Party", "Veggie")
            };

            //Using Builder to create one Chicken MenuItem just to demonstrate that it works
            HotWingsBuilder hotWing = new HotWingsBuilder();            

            chickens = new List<IMenuItem>
            {
                hotWing.GetMenuItem(),
                new ChickenFactory().CreateMenuItem("PlainWings"),
                new ChickenFactory().CreateMenuItem("BBQWings")
            };

            ComboCollection HHCombo = new ComboCollection();
            ComboCollection VGCombo = new ComboCollection();

            var HHFactory = new HawaiianHotFactory();
            HHCombo[1] = HHFactory.CreatePizza();
            HHCombo[2] = HHFactory.CreateWings();


            var VGFactory = new VeggiePlainFactory();
            VGCombo[1] = VGFactory.CreatePizza();
            VGCombo[2] = VGFactory.CreateWings();

            combos.Add(HHCombo.CreateIterator());
            combos.Add(VGCombo.CreateIterator());

        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            ViewBag.Title = "bouffe - Food Delivery";

            //PizzasViewModel allPizzas = new PizzasViewModel(pizzas);
            //return View(allPizzas);
            PizzaCollection pizzaz = new PizzaCollection();
            for(int i = 0; i < pizzas.Count(); i++)
            {
                pizzaz[i] = pizzas.ElementAt(i);
            }
            
            ChickenCollection chickenz = new ChickenCollection();
            for (int i = 0; i < chickens.Count(); i++)
            {
                chickenz[i] = chickens.ElementAt(i);
            }
            IGenericIterator pizzaIterator = pizzaz.CreateIterator();
            IGenericIterator chickenIterator = chickenz.CreateIterator();
            //MenuViewModel allItems = new MenuViewModel(pizzaz);

            //IEnumerable<IGenericIterator> menuItems = Enumerable.Empty<IGenericIterator>();
            List<IGenericIterator> menuItems = new List<IGenericIterator>();
            
            
            menuItems.Add(pizzaIterator);
            menuItems.Add(chickenIterator);

            //MenuViewModel allItems = new MenuViewModel(iterator);
            MenuViewModel allItems = new MenuViewModel(menuItems);
            return View(allItems);
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Faq()
        {
            return View();
        }
    }
}
