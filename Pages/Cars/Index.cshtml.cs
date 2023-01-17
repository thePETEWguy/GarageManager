using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GarageManager.Data;
using GarageManager.Models;

namespace GarageManager.Pages.Cars
{
    public class IndexModel : PageModel
    {
        private readonly GarageManager.Data.GarageManagerContext _context;

        public IndexModel(GarageManager.Data.GarageManagerContext context)
        {
            _context = context;
        }

        public IList<Car> Car { get;set; } = default!;

        public CarData CarData { get; set; }
        public int CarID { get; set; }
        public int ServiceID { get; set; }

        public async Task OnGetAsync(int? id, int? serviceID)
        {
            CarData = new CarData
            {
                Cars = await _context.Car
                .Include(c => c.Mechanic)
                .Include(c => c.CarServices).ThenInclude(c => c.Service)
                .AsNoTracking()
                .OrderBy(c => c.ModelName)
                .ToListAsync(),
                Services = await _context.Service
                .AsNoTracking()
                .OrderBy(s => s.ServiceName)
                .ToListAsync()
            };

            if (id != null)
            {
                CarID = id.Value;
                Car car = CarData.Cars
                .Where(i => i.ID == id.Value).Single();
                CarData.Services = car.CarServices.Select(s => s.Service);
            }
        }
    }
}
