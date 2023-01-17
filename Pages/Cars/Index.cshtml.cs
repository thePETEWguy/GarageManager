﻿using System;
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

        public async Task OnGetAsync()
        {
            if (_context.Car != null)
            {
                Car = await _context.Car
                    .Include(c => c.Mechanic)
                    .ToListAsync();
            }
        }
    }
}
