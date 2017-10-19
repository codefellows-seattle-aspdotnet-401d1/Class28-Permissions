using Microsoft.AspNetCore.Mvc;
using IdentityDay2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdentityDay2.Controllers
{
    public class HomeController : Controller
    {
        //private field, used for Dependendcy Injection
        private readonly IdentityDay2Context _context;


        //Constructor for Home Controller - a DBContext is required
        public HomeController(IdentityDay2Context context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            // Calling to the CMS table in the database and getting the content for ID 1
            var result = _context.CMS.Where(c => c.ID > 0);

            return View(result.ToList());
        }
    }
}
