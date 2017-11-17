using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab28Erik.Models
{
    public class Lab28ErikContext : DbContext
    {
        public Lab28ErikContext (DbContextOptions<Lab28ErikContext> options)
            : base(options)
        {
        }

        public DbSet<Lab28Erik.Models.Product> Product { get; set; }
    }
}
