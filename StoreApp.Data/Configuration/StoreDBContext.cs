using Microsoft.EntityFrameworkCore;
using StoreApp.Domain.BusinessEntities.Items;
using StoreApp.Domain.BusinessEntities.Orders;
using System;
using System.Collections.Generic;
using System.Text;

namespace StoreApp.Data.Configuration
{
    public class StoreDBContext:DbContext
    {
        public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        {

        }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ItemEntityConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
