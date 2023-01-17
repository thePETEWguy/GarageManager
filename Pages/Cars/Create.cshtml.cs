using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GarageManager.Data;
using GarageManager.Models;
using System.Security.Policy;

namespace GarageManager.Pages.Cars
{
    public class CreateModel : CarServicesPageModel
    {
        private readonly GarageManager.Data.GarageManagerContext _context;

        public CreateModel(GarageManager.Data.GarageManagerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["MechanicID"] = new SelectList(_context.Set<Mechanic>(), "ID", "MechanicName");

            var car = new Car();
            car.CarServices = new List<CarService>();

            PopulateSelectedServices(_context, car);

            return Page();
        }

        [BindProperty]
        public Car Car { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync(string[] selectedServices)
        {
            var newCar = new Car();
            if (selectedServices != null)
            {
                newCar.CarServices = new List<CarService>();
                foreach (var service in selectedServices)
                {
                    var serviceToAdd = new CarService
                    {
                        ServiceID = int.Parse(service)
                    };
                    newCar.CarServices.Add(serviceToAdd);
                }
            }

            newCar.ModelName = Car.ModelName;
            newCar.LicensePlate = Car.LicensePlate;
            newCar.ServicePrice = Car.ServicePrice;
            newCar.Owner = Car.Owner;
            newCar.ServiceDate = Car.ServiceDate;
            newCar.MechanicID = Car.MechanicID;

            _context.Car.Add(newCar);
            await _context.SaveChangesAsync();
            PopulateSelectedServices(_context, newCar);

            return RedirectToPage("./Index");
        }
    }
}
