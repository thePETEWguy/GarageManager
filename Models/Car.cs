using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace GarageManager.Models
{
    public class Car
    {
        public int ID { get; set; }

        [Display(Name = "Model Name")]
        public string ModelName { get; set; }

        [Display(Name = "License Plate")]
        public string LicensePlate { get; set; }
        public string Owner { get; set; }

        [Display(Name = "Service Price")]
        [Column(TypeName = "decimal(6, 2)")]
        public decimal ServicePrice { get; set; }

        [Display(Name = "Service Date")]
        [DataType(DataType.Date)]
        public DateTime ServiceDate { get; set; }

        public int MechanicID { get; set; }
        public Mechanic? Mechanic { get; set; } // navigation property

        public ICollection<CarService>? CarServices { get; set; }
    }
}
