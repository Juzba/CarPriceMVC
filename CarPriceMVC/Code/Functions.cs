using CarPriceMVC.Models;
using System.Xml.Linq;

namespace CarPriceMVC.Code;

public class Functions(ApplicationDbContext db, ILogger<Functions> logger)
{
    private readonly ApplicationDbContext _db = db;
    private readonly ILogger<Functions> _logger = logger;


    public async Task<bool> XmlToDB(IFormFile XmlFile)
    {

        if (XmlFile == null || XmlFile.Length == 0) return false;

        using var stream = XmlFile.OpenReadStream();
        XDocument xDocument = XDocument.Load(stream);

        var data = xDocument.Descendants("Data").Descendants("Car")
            .Where(p => p.Element("Name") != null)
            .Select(p => new Car()
            {
                Name = p.Element("Name")!.Value,
                DateT = DateTime.TryParse(p.Element("Date")?.Value, out DateTime dt) ? dt : default,
                Price = double.TryParse(p.Element("Price")?.Value.Remove(p.Element("Price")!.Value.Length - 2).Replace(".", ""), out double price) ? price : default,
                DPH = double.TryParse(p.Element("DPH")?.Value, out double dph) ? dph : default
            }).ToList();

        if (data == null) return false;

        await _db.AddRangeAsync(data);
        await _db.SaveChangesAsync();


        return true;
    }



    public Car RandomCar()
    {
        Random rnd = new();
        List<(string, int)> cars = [("Škoda Oktávia", 50),("Škoda Felicia",21),("Škoda Fabia",35),("Škoda Favorit",8),("Škoda Forman",10)];
        
        DateTime dateTime = new(rnd.Next(2000, 2025), rnd.Next(1, 12), rnd.Next(1, 29), rnd.Next(0, 23), rnd.Next(0, 59), rnd.Next(0, 59));
        var rndCar = cars[rnd.Next(0, cars.Count)];

        Car car = new()
        {
            Name = rndCar.Item1,
            DateT = dateTime,
            Price = rnd.Next(rndCar.Item2 - rndCar.Item2/5, rndCar.Item2 + rndCar.Item2 /5) * 10000,
            DPH = dateTime.Year > 2005 ? 20 : 19
        };

        return car;
    }
}

