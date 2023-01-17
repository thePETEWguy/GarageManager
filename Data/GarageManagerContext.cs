using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GarageManager.Models;

namespace GarageManager.Data
{
    public class GarageManagerContext : DbContext
    {
        public GarageManagerContext (DbContextOptions<GarageManagerContext> options)
            : base(options)
        {
        }

        public DbSet<GarageManager.Models.Car> Car { get; set; } = default!;

        public DbSet<GarageManager.Models.Mechanic> Mechanic { get; set; }

        public DbSet<GarageManager.Models.Category> Category { get; set; }
    }
}
