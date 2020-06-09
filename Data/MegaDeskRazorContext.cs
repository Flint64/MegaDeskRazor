using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Data
{
    public class MegaDeskRazorContext : DbContext
    {
        public MegaDeskRazorContext (DbContextOptions<MegaDeskRazorContext> options)
            : base(options)
        {
        }

        public DbSet<RushOption> RushOption { get; set; }
        public DbSet<Desk> Desk { get; set; }
        public DbSet<SurfaceMaterial> SurfaceMaterial { get; set; }
        public DbSet<NumDrawers> NumDrawers { get; set; }

        public DbSet<MegaDeskRazor.Models.DeskQuote> DeskQuote { get; set; }
    }
}
