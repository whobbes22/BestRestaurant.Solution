using System.Collections.Generic;

namespace FavoriteRestaurant.Models
{
  public class Restaurant
  {
    public int RestaurantId { get; set; }
    public string RestaurantName { get; set; }
    public string RestaurantHealthCode { get; set; }
    public int RestaurantRating { get; set;}
    public int CuisineId { get; set; }
    public Cuisine Cuisine { get; set; }
  }
}