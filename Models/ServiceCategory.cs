namespace GarageManager.Models
{
    public class ServiceCategory
    {
        public int ID { get; set; }
        public int CarID { get; set; }
        public Car car { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }

    }
}
