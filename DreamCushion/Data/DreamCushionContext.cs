using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DreamCushion.Models;

namespace DreamCushion.Data
{
    public class DreamCushionContext : DbContext
    {
        public DreamCushionContext (DbContextOptions<DreamCushionContext> options)
            : base(options)
        {
        }

        public DbSet<DreamCushion.Models.Pillow> Pillow { get; set; } = default!;
    }
}
