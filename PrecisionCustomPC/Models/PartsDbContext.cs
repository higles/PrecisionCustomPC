using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace PrecisionCustomPC.Models
{
    public class PartsDbContext : DbContext
    {
        public PartsDbContext(DbContextOptions<PartsDbContext> options)
            : base(options)
        {
        }

        public DbSet<PartsViewModels.Tower> Towers { get; set; }
        public DbSet<PartsViewModels.Motherboard> Motherboards { get; set; }
        public DbSet<PartsViewModels.Color> Colors { get; set; }
        public DbSet<PartsViewModels.Image> Images { get; set; }
    }
}
