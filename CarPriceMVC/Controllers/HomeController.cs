using Microsoft.AspNetCore.Mvc;

namespace CarPriceMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddCar()
        {
            return View();
        }


    }
}
