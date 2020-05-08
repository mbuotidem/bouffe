using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bouffe.Models;
using bouffe.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace bouffe.Controllers
{
    public class OrderCartController : Controller
    {
        private readonly AppDbContext _context;

        private readonly OrderCart _orderCart;

        public OrderCartController(AppDbContext context, OrderCart orderCart)
        {
            _context = context;
            _orderCart = orderCart;
        }



        public ViewResult Index()
        {
            var items = _orderCart.GetOrderItems();
            _orderCart.OrderItems = items;

            var cartViewModel = new CartViewModel
            {
                OrderCart = _orderCart,
                OrderTotal = _orderCart.GetOrderTotal()
            };

            return View(cartViewModel);
        }

        public RedirectToActionResult AddToCart(int itemId)
        {
            var selectedItem = _context.MenuItems.FirstOrDefault(i => i.Id == itemId);

            if (selectedItem != null)
            {
                _orderCart.AddToCart(selectedItem, 1);
            }
            return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart (int itemId)
        {
            var selectedItem = _context.MenuItems.FirstOrDefault(i => i.Id == itemId);

            if (selectedItem != null)
            {
                _orderCart.RemoveFromCart(selectedItem);
            }
            return RedirectToAction("Index");
        }
    }
}
