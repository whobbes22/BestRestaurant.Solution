using Microsoft.AspNetCore.Mvc;

namespace FavoriteRestaurant.Controllers
{
    public class HomeController : Controller
    {

      [HttpGet("/")]
      public ActionResult Index()
      {
        return View();
      }

    }
}