using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FavoriteRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteRestaurant.Controllers
{
  public class RestaurantsController : Controller
  {
    private readonly FavoriteRestaurantContext _db;
    public RestaurantsController(FavoriteRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Restaurant> model = _db.Restaurants
                                  .OrderBy(restaurant => restaurant.Cuisine)
                                  .ToList();
      return View(model);
    }
  }
}