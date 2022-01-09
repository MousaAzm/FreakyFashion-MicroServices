
using FreakyFashionServices.OrderProcessor.Models.DbModel;
using Microsoft.EntityFrameworkCore;

namespace FreakyFashionServices.OrderProcessor.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options)
          : base(options)
        {

        }

        public DbSet<Order> Orders { get; set; } = null!;
        public DbSet<OrderLine> OrderLines { get; set; } = null!;
        public DbSet<OrderCart> OrderCarts { get; set; } = null!;

    }
}

