using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public HomeController()
        {
            pizzaTypes = new List<PizzaType>
            {
                new PizzaType {PizzaTypeId = 1, PizzaTypeName = "Hawaiian", Description = "Tropical" },
                new PizzaType {PizzaTypeId = 1, PizzaTypeName = "Pepperoni", Description = "Pepperish" },
                new PizzaType {PizzaTypeId = 1, PizzaTypeName = "Vegetarian", Description = "Herbivores" }
            };
            pizzas = new List<Pizza>
            {
                new Pizza {PizzaId = 1, Name = "Hawaiian Delight", Price = 5.99M, ShortDesc = "Ham and Pineapple",PizzaType = pizzaTypes.First(), ImageThumbUrl="/images/hawaiian.jpg"},
                new Pizza {PizzaId = 1, Name = "Pepperoni Mashup", Price = 5.99M, ShortDesc = "Cheese", PizzaType = pizzaTypes.ElementAt(1), ImageThumbUrl="/images/pepperoni.jpg" },
                new Pizza {PizzaId = 1, Name = "Veggie Party", Price = 5.99M, ShortDesc = "Vegetables", PizzaType = pizzaTypes.Last(), ImageThumbUrl="/images/veggie.jpg"}

            };
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            PizzasViewModel allPizzas = new PizzasViewModel(pizzas);
            ViewBag.Title = "bouffe-Pizza Delivery";
            return View(allPizzas);
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
