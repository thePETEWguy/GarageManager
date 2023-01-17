namespace GarageManager.Models
{
    public class CarService
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public Car car { get; set; }
        public int ServiceID { get; set; }
        public Service Service { get; set; }

    }
}
