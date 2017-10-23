using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using lab28Permissions.Models;

namespace lab28Permissions.Controllers
{
    public class HomeController : Controller
    {
        private readonly lab28PermissionsContext _context;

        public HomeController(lab28PermissionsContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Recipe;

            return View(result.ToList());
        }
    }
}