using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GarageManager.Models
{
    public class Service
    {
        public int ID { get; set; }

        [Display(Name = "Service Name")]
        public string ServiceName { get; set; }
        public ICollection<CarService>? ServiceCategories { get; set; }
    }
}
