using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FavoriteRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteRestaurant.Controllers
{
  public class CuisinesController : Controller
  {
    private readonly FavoriteRestaurantContext _db;
    public CuisinesController (FavoriteRestaurantContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Cuisine> model = _db.Cuisines.ToList();
      return View(model);
    }

    public ActionResult Create()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Create(Cuisine cuisine)
    {
      _db.Cuisines.Add(cuisine);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Cuisine thisCuisine = _db.Cuisines
                                .Include(cuisine => cuisine.Restaurants)
                                .FirstOrDefault(cuisine => cuisine.CuisineId == id);
      return View(thisCuisine);
    }
  }
}