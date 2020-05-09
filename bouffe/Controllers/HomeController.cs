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
        IEnumerable<Pizza> pizzas = Enumerable.Empty<Pizza>();
        IEnumerable<ChickenType> chickenTypes = Enumerable.Empty<ChickenType>();
        IEnumerable<Chicken> chickens = Enumerable.Empty<Chicken>();

        public HomeController()
        {
            pizzaTypes = new List<PizzaType>
            {
                new PizzaType {PizzaTypeId = 1, PizzaTypeName = "Hawaiian", Description = "Tropical" },
                new PizzaType {PizzaTypeId = 2, PizzaTypeName = "Pepperoni", Description = "Pepperish" },
                new PizzaType {PizzaTypeId = 3, PizzaTypeName = "Vegetarian", Description = "Herbivores" }
            };
            pizzas = new List<Pizza>
            {
                new Pizza {Id = 1, Name = "Hawaiian Delight", Price = 5.99M, ShortDesc = "Ham and Pineapple",PizzaType = pizzaTypes.First(), ImageThumbUrl="/images/hawaiian.jpg"},
                new Pizza {Id = 2, Name = "Pepperoni Mashup", Price = 5.99M, ShortDesc = "Cheese", PizzaType = pizzaTypes.ElementAt(1), ImageThumbUrl="/images/pepperoni.jpg" },
                new Pizza {Id = 3, Name = "Veggie Party", Price = 5.99M, ShortDesc = "Vegetables", PizzaType = pizzaTypes.Last(), ImageThumbUrl="/images/veggie.jpg"}

            };

            chickenTypes = new List<ChickenType>
            {
                new ChickenType {ChickenTypeId = 1, ChickenTypeName = "Wings", Description = "Delicious" }
            };

            HotWingsBuilder chick = new HotWingsBuilder();
            chick.build();
            chickens = new List<Chicken>
            {
                //new Chicken {Id = 1, Name = "Hotwings", Price = 5.99M, ShortDesc = "They're hot!",ChickenType = chickenTypes.First(), ImageThumbUrl="/images/hotwings.jpg"},
                new Chicken {Id = 1, Name = "BBQwings", Price = 5.99M, ShortDesc = "They're bbq!",ChickenType = chickenTypes.First(), ImageThumbUrl="/images/bbqwings.jpg"},
                new Chicken {Id = 1, Name = "PlainWings", Price = 5.99M, ShortDesc = "They're plain!",ChickenType = chickenTypes.First(), ImageThumbUrl="/images/plainwings.jpg"},
                //(Chicken)new ChickenFactory().CreateMenuItem("Hotwings"),
                (Chicken)chick.MenuItem

            };
            
            //chickens.Append(new ChickenFactory().CreateMenuItem("Hotwings"));
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
