using CarPriceMVC.Code;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace CarPriceMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();

        public IActionResult AddCar() => View();

        public IActionResult AddXmlToDB() => View();

        [HttpPost]
        public IActionResult AddXmlToDB(IFormFile XmlFile) 
        {
            return Functions.XmlToDB(XmlFile) ? RedirectToAction("Index", "Home") : View();
        }


    }
}
