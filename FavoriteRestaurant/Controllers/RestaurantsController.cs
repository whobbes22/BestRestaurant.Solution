using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
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
      List<Restaurant> model = _db.Restaurants.ToList();
                                  // .Include(restaurant => restaurant.Cuisine)
                                  
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Restaurant restaurant)
    {
      _db.Restaurants.Add(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Restaurant cRestaurant = _db
                            .Restaurants
                            .FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(cRestaurant);
    }
  }
}