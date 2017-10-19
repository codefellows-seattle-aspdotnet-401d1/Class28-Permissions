using Lab28George.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Lab28George.Controllers
{
    public class HomeController : Controller
    {
        private readonly Lab28GeorgeContext _context;

        //constructor and dependency injection
        public HomeController(Lab28GeorgeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // I'm just grabbing the players that aren't game masters
            // I could do this filtering on the index page, but I prefer for it to be behind the scenes
            var result = _context.Player.Where(p => p.GameMaster == false);
            // sends my list of results to the view
            return View(result.ToList());
        }
    }
}
