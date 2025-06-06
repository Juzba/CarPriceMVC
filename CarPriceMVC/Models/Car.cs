using System.ComponentModel.DataAnnotations;

namespace CarPriceMVC.Models
{
    public class Car
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Zadej název!")]
        [StringLength(50,ErrorMessage = "Jméno může mít maximálně 50 znaků.")]
        public string? Name { get; set; }

        [Required(ErrorMessage ="Zadej datum!")]
        public DateTime DateT { get; set; }

        [Required(ErrorMessage ="Zadej cenu.")]
        [Range(1,99999999, ErrorMessage ="Zadej cenu v rozmezí 1 - 99999999")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Zadej Dph.")]
        [Range(1, 100, ErrorMessage = "Zadej cenu v rozmezí 1 - 100")]
        public double DPH { get; set; }
    }
}
