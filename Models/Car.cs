namespace GarageManager.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string ModelName { get; set; }
        public string LicensePlate { get; set; }
        public string Owner { get; set; }
        public decimal ServicePrice { get; set; }
    }
}
