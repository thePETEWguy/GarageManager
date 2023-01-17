namespace GarageManager.Models
{
    public class CarData
    {
        public IEnumerable<Car> Cars { get; set; }
        public IEnumerable<Service> Services { get; set; }
        public IEnumerable<CarService> CarServices { get; set; }
    }
}
