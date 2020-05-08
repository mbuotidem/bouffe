using bouffe.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bouffe.Models
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        #region Required
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Pizza>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");
            modelBuilder.Entity<Chicken>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");
        }
        #endregion

        public DbSet<AMenuItem> MenuItems { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Chicken> Chickens { get; set; }

        public DbSet<PizzaType> PizzaTypes { get; set; }

        public DbSet<ChickenType> ChickenTypes { get; set; }

        public DbSet<OrderItem> OrderItems{ get; set; }

    }
}
