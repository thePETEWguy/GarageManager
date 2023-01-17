using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GarageManager.Data;
using GarageManager.Models;

namespace GarageManager.Pages.Mechanics
{
    public class DetailsModel : PageModel
    {
        private readonly GarageManager.Data.GarageManagerContext _context;

        public DetailsModel(GarageManager.Data.GarageManagerContext context)
        {
            _context = context;
        }

      public Mechanic Mechanic { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Mechanic == null)
            {
                return NotFound();
            }

            var mechanic = await _context.Mechanic.FirstOrDefaultAsync(m => m.ID == id);
            if (mechanic == null)
            {
                return NotFound();
            }
            else 
            {
                Mechanic = mechanic;
            }
            return Page();
        }
    }
}
