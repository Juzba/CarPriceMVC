using CarPriceMVC.Code;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPriceMVC.Controllers
{
    public class HomeController(Functions fc) : Controller
    {
        private readonly Functions _fc = fc;

        public IActionResult Index() => View();

        public IActionResult AddCar() => View();

        public IActionResult AddXmlToDB() => View();

        [HttpPost]
        public async Task<IActionResult> AddXmlToDB(IFormFile XmlFile) 
        {
            return await _fc.XmlToDB(XmlFile) ? RedirectToAction("Index", "Home") : View((object) "Musíš vybrat soubor!!");
        }


    }
}
