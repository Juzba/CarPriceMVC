using CarPriceMVC.Code;
using CarPriceMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarPriceMVC.Controllers
{
    public class HomeController(Functions fc, ApplicationDbContext db) : Controller
    {
        private readonly Functions _fc = fc;
        private readonly ApplicationDbContext _db = db;

        public IActionResult Index() => View();

        public IActionResult EditCar() => View(_fc.RandomCar());

        public IActionResult AddXmlToDB() => View();
        public async Task<IActionResult> Result() => View(await _db.Cars.ToListAsync());
        public async Task<IActionResult> List() => View(await _db.Cars.ToListAsync());

        public async Task<IActionResult> DeleteAll()
        {
            await _db.Database.ExecuteSqlRawAsync("DELETE FROM Cars");
            return RedirectToAction("List", "Home");
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (int.TryParse(id, out int parsedID))
            {
                _db.Entry(new Car() { Id = parsedID }).State = EntityState.Deleted;
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("List", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> AddXmlToDB(IFormFile XmlFile)
        {
            return await _fc.XmlToDB(XmlFile) ? RedirectToAction("List", "Home") : View((object)"Musíš vybrat soubor!!");
        }

        [HttpPost]
        public async Task<IActionResult> EditCar(Car car)
        {
            if (!ModelState.IsValid) return View(car);
            await _db.AddAsync(car);
            await _db.SaveChangesAsync();

            return RedirectToAction("List", "Home");
        }
    }
}
