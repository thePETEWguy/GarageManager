using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GarageManager.Models
{
    public class Mechanic
    {
        public int ID { get; set; }

        [Display(Name = "Mechanic Name")]
        public string MechanicName { get; set; }

        public ICollection<Car>? Cars { get; set; } // navigation property
    }
}
