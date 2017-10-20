using Lab28Roles.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab28Roles.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lab28RolesContext _context;

        public HomeController(Lab28RolesContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var result = _context.VideoGames.Where(v => v.ID > 0);
            return View(result.ToList());
        }
    }
}
