using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bouffe.Models;
using bouffe.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace bouffe.Controllers
{
    public class PizzaController : Controller
    {
        IEnumerable<PizzaType> pizzaTypes = Enumerable.Empty<PizzaType>();
        IEnumerable<Pizza> pizzas = Enumerable.Empty<Pizza>();
        
        public PizzaController()
        {
            pizzaTypes = new List<PizzaType>
            {
                new PizzaType {PizzaTypeId = 1, PizzaTypeName = "Hawaiian", Description = "Tropical" },
                new PizzaType {PizzaTypeId = 1, PizzaTypeName = "Pepperoni", Description = "Pepperish" },
                new PizzaType {PizzaTypeId = 1, PizzaTypeName = "Vegetarian", Description = "Herbivores" }
            };
            pizzas = new List<Pizza>
            {
                new Pizza {Id = 1, Name = "Hawaiian Delight", Price = 5.99M, ShortDesc = "Ham and Pineapple",PizzaType = pizzaTypes.First(), ImageThumbUrl="/images/hawaiian.jpg"},
                new Pizza {Id = 1, Name = "Pepperoni Mashup", Price = 5.99M, ShortDesc = "Cheese", PizzaType = pizzaTypes.ElementAt(1), ImageThumbUrl="/images/pepperoni.jpg" },
                new Pizza {Id = 1, Name = "Veggie Party", Price = 5.99M, ShortDesc = "Vegetables", PizzaType = pizzaTypes.Last(), ImageThumbUrl="/images/veggie.jpg"}

            };
        }
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            PizzasViewModel allPizzas = new PizzasViewModel(pizzas);
            return View(allPizzas);
        }
    }
}