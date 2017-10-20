using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Lab28Roles.Models
{
    public class Lab28RolesContext : DbContext
    {
        public Lab28RolesContext (DbContextOptions<Lab28RolesContext> options)
            : base(options)
        {
        }

        public DbSet<Lab28Roles.Models.VideoGames> VideoGames { get; set; }
    }
}
