using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GarageManager.Models;

namespace GarageManager.Pages.Cars
{
    public class EditModel : CarServicesPageModel
    {
        private readonly GarageManager.Data.GarageManagerContext _context;

        public EditModel(GarageManager.Data.GarageManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Car == null)
            {
                return NotFound();
            }

            Car = await _context.Car
                 .Include(c => c.Mechanic)
                 .Include(c => c.CarServices)
                 .ThenInclude(c => c.Service)
                 .AsNoTracking()
                 .FirstOrDefaultAsync(m => m.ID == id);

            if (Car == null)
            {
                return NotFound();
            }

            PopulateSelectedServices(_context, Car);

            ViewData["MechanicID"] = new SelectList(_context.Set<Mechanic>(), "ID", "MechanicName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedServices)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (id == null)
            {
                return NotFound();
            }

            var car = await _context.Car
                .Include(i => i.Mechanic)
                .Include(i => i.CarServices)
                .ThenInclude(i => i.Service)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (car == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                car,
                "Car",
                i => i.ModelName,
                i => i.ServicePrice,
                i => i.Owner,
                i => i.ServiceDate,
                i => i.Mechanic))
            {
                UpdateCarServices(_context, selectedServices, car);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateCarServices(_context, selectedServices, car);
            PopulateSelectedServices(_context, car);
            return Page();
        }

        private bool CarExists(int id)
        {
          return _context.Car.Any(e => e.ID == id);
        }
    }
}
