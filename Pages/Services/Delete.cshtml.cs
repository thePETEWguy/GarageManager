using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GarageManager.Data;
using GarageManager.Models;

namespace GarageManager.Pages.Services
{
    public class DeleteModel : PageModel
    {
        private readonly GarageManager.Data.GarageManagerContext _context;

        public DeleteModel(GarageManager.Data.GarageManagerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Service Service { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }

            var Service = await _context.Service.FirstOrDefaultAsync(m => m.ID == id);

            if (Service == null)
            {
                return NotFound();
            }
            else 
            {
                Service = Service;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Service == null)
            {
                return NotFound();
            }
            var Service = await _context.Service.FindAsync(id);

            if (Service != null)
            {
                Service = Service;
                _context.Service.Remove(Service);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
