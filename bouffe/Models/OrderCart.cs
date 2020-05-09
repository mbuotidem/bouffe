//Adapted from
//https://www.pluralsight.com/courses/building-aspdotnet-core-mvc-web-applications

using bouffe.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace bouffe.Models
{
    public class OrderCart
    {
        private readonly AppDbContext appDbContext;
        public string OrderCartId { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        //We pass the database context in via constructor injection
        private OrderCart(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        //We access the collection of services managed in the dependency injection container
        public static OrderCart GetCart(IServiceProvider services)
        {
            //This allows support for sessions in order to share state between the 
            //server and the client
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?
                .HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            //We represent a shopping cart in memory using a GUID string that we'll
            //store in the session. If there is already an active session containing a cartId,
            //we grab that, if not, we create a new one
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new OrderCart(context) { OrderCartId = cartId };

        }

        public void AddToCart(AMenuItem item, int amount)
        {
            //Check database to see if menuItem is already in Orders
            var cartItem = appDbContext.OrderItems.SingleOrDefault(
                s => s.MenuItem.Id == item.Id && s.OrderId == OrderCartId);
            
            //If not, create it and add to the database
            if (cartItem == null)
            {
                cartItem = new OrderItem
                {
                    OrderId = OrderCartId,
                    MenuItem = item,
                    Amount = 1
                };

                appDbContext.OrderItems.Add(cartItem);
            }

            //If it is, then just increase the amount
            else
            {
                cartItem.Amount++;
            }

            //commit changes to database
            appDbContext.SaveChanges();
        }

        public int RemoveFromCart(AMenuItem item)
        {
            //Check database for item
            var cartItem =
                appDbContext.OrderItems.SingleOrDefault(
                    s => s.MenuItem.Id == item.Id && s.OrderId == OrderCartId);

            var localAmount = 0;

            //Reduce amount or remove from cart entirely if only one item
            if (cartItem != null)
            {
                if (cartItem.Amount > 1)
                {
                    cartItem.Amount--;
                    localAmount = cartItem.Amount;
                }
                else
                {
                    appDbContext.OrderItems.Remove(cartItem);
                }
            }

            appDbContext.SaveChanges();

            return localAmount;

        }

        public List<OrderItem> GetOrderItems()
        {
            //Check if items were already retrieved, if not, do so
            return OrderItems ??
                (OrderItems =
                appDbContext.OrderItems.Where(c => c.OrderId == OrderCartId)
                .Include(s => s.MenuItem)
                .ToList());
        }

        public void ClearCart()
        {
            //Get all items in cart and remove
            var cartItems = appDbContext
                .OrderItems.Where(cart => cart.OrderId == OrderCartId);

            appDbContext.OrderItems.RemoveRange(cartItems);

            appDbContext.SaveChanges();
        }

        //Sum all the items in the cart.
        public decimal GetOrderTotal()
        {
            var total = appDbContext.OrderItems.Where(c => c.OrderId == OrderCartId)
                .Select(c => c.MenuItem.Price * c.Amount).Sum();

            return total;
        }

    }
}
