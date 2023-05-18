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
      List<Restaurant> model = _db.Restaurants
                                  .Include(restaurant => restaurant.Cuisine)
                                  .ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "CuisineType");
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

    public ActionResult Delete(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      return View(thisRestaurant);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Restaurant thisRestaurant = _db.Restaurants.FirstOrDefault(restaurant => restaurant.RestaurantId == id);
      _db.Restaurants.Remove(thisRestaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Edit(int id)
    {
      Restaurant cRestaurant = _db.Restaurants
                                  .FirstOrDefault(rest => rest.RestaurantId == id);
      ViewBag.CuisineId = new SelectList(_db.Cuisines, "CuisineId", "CuisineType");
      return View(cRestaurant);
    }

    [HttpPost]
    public ActionResult Edit(Restaurant restaurant)
    {
      _db.Restaurants.Update(restaurant);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}