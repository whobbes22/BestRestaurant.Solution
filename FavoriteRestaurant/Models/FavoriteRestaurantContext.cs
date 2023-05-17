using Microsoft.EntityFrameworkCore;

namespace FavoriteRestaurant.Models
{
  public class FavoriteRestaurantContext : DbContext
  {
    //public DbSet<Category> Categories {get;set;}
    //public DbSet<Item> Items { get; set; }

    public FavoriteRestaurantContext(DbContextOptions options) : base(options) { }
  }
}