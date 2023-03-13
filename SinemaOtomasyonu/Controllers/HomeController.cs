using Microsoft.AspNetCore.Mvc;
using SinemaOtomasyonu.Models;
using System.Diagnostics;

namespace SinemaOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        private DataContext context;

        public HomeController(DataContext _context)
        {
            context = _context;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult KayıtOl()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}