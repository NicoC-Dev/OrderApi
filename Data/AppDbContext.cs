
using Microsoft.EntityFrameworkCore;
using OrdersApi.Models;

namespace MaestroApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    

    public DbSet<Product> Products => Set<Product>();
    public DbSet<OrderDetail> OrderDetails => Set<OrderDetail>();
    public DbSet<Order> Orders => Set<Order>();

}