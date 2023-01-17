using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GarageManager.Data;

namespace GarageManager.Models
{
    public class CarServicesPageModel : PageModel
    {
        public List<SelectedService> SelectedServiceList;
        public void PopulateSelectedServices(GarageManagerContext context, Car car)
        {
            var allServices = context.Service;
            var carServices = new HashSet<int>(
            car.CarServices.Select(c => c.ServiceID)); //
            SelectedServiceList = new List<SelectedService>();
            foreach (var service in allServices)
            {
                SelectedServiceList.Add(new SelectedService
                {
                    ServiceID = service.ID,
                    Name = service.ServiceName,
                    Selected = carServices.Contains(service.ID)
                });
            }
        }
        public void UpdateCarServices(GarageManagerContext context,
        string[] selectedCategories, Car car)
        {
            if (selectedCategories == null)
            {
                car.CarServices = new List<CarService>();
                return;
            }
            var selectedServicesHS = new HashSet<string>(selectedCategories);
            var carServices = new HashSet<int>
            (car.CarServices.Select(s => s.Service.ID));
            foreach (var service in context.Service)
            {
                if (selectedServicesHS.Contains(service.ID.ToString()))
                {
                    if (!carServices.Contains(service.ID))
                    {
                        car.CarServices.Add(
                        new CarService
                        {
                            CarID = car.ID,
                            ServiceID = service.ID
                        });
                    }
                }
                else
                {
                    if (carServices.Contains(service.ID))
                    {
                        CarService toBeRemoved
                        = car
                        .CarServices
                        .SingleOrDefault(i => i.ServiceID == service.ID);
                        context.Remove(toBeRemoved);
                    }
                }
            }
        }
    }
}
