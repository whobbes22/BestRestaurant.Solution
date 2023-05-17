using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using FavoriteRestaurant.Models;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteRestaurant.Controllers
{
  public class CuisinesController : Controller
  {

    public ActionResult Index()
    {
      return View();
    }
  }
}