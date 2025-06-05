using CarPriceMVC.Models;
using System.Xml.Linq;

namespace CarPriceMVC.Code;

public class Functions(ApplicationDbContext db, ILogger<Functions> logger)
{
    private readonly ApplicationDbContext _db = db;
    private readonly ILogger<Functions> _logger = logger;


    public static bool XmlToDB(IFormFile XmlFile)
    {

        if (XmlFile == null || XmlFile.Length == 0) return false;

        using var stream = XmlFile.OpenReadStream();
        XDocument xDocument = XDocument.Load(stream);

        var neco = xDocument.Descendants("Data").Descendants("Car")
            .Select(p => p.Element("Name").Value).ToList();





        foreach (var item in neco)
        {
          Console.WriteLine(item);

        }









        return true;
    }


}

