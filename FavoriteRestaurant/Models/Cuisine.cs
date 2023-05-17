using System.Collections.Generic;

namespace FavoriteRestaurant.Models
{
  public class Cuisine
  {
    public int CusineId {get; set;}
    public string CuisineType {get; set;}
    public List<Restaurant> Restaurants { get; set; }
  }
}
