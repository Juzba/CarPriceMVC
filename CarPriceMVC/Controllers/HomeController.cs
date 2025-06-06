using CarPriceMVC.Code;
using CarPriceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarPriceMVC.Controllers
{
    public class HomeController(Functions fc, ApplicationDbContext db) : Controller
    {
        private readonly Functions _fc = fc;
        private readonly ApplicationDbContext _db = db;

        public IActionResult Index() => View();

        public IActionResult EditCar() => View(new Car() { DateT = DateTime.Now});

        public IActionResult AddXmlToDB() => View();

        [HttpPost]
        public async Task<IActionResult> AddXmlToDB(IFormFile XmlFile) 
        {
            return await _fc.XmlToDB(XmlFile) ? RedirectToAction("Index", "Home") : View((object) "Musíš vybrat soubor!!");
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(Car car)
        {
            if (!ModelState.IsValid) return View(car);
            await _db.AddAsync(car);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
