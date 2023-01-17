namespace GarageManager.Models
{
    public class Mechanic
    {
        public int ID { get; set; }

        public string MechanicName { get; set; }

        public ICollection<Car>? Cars { get; set; } // navigation property
    }
}
