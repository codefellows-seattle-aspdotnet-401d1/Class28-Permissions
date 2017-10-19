using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab28George.Models
{
    public class Lab28GeorgeContext : DbContext
    {
        public Lab28GeorgeContext (DbContextOptions<Lab28GeorgeContext> options)
            : base(options)
        {
        }

        public DbSet<Lab28George.Models.Player> Player { get; set; }
    }
}
