namespace CarPriceMVC.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime DateT { get; set; }

        public double Price { get; set; }

        public double DPH { get; set; }
    }
}
