using Builders_Deck.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Builders_Deck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult blog()
        {
            return View();
        }

        public IActionResult BlogDetails()
        {
            return View();
        }

        public IActionResult contact()
        {
            return View();
        }

        public IActionResult ProjectDetails()
        {
            return View();
        }

        public IActionResult projects()
        {
            return View();
        }

        public IActionResult ServiceDetails()
        {
            return View();
        }
        public IActionResult services()
        {
            return View();
        }

        public IActionResult StarterPage()
        {
            return View();
        }

        public IActionResult Privacy()
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
