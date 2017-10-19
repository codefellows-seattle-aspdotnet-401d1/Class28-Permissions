using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lab28Permissions.Models
{
    public class lab28PermissionsContext : DbContext
    {
        public lab28PermissionsContext (DbContextOptions<lab28PermissionsContext> options)
            : base(options)
        {
        }

        public DbSet<lab28Permissions.Models.Recipe> Recipe { get; set; }
    }
}
