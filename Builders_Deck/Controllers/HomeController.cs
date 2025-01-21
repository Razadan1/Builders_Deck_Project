using Builders_Deck.Data;
using Builders_Deck.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Builders_Deck.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(QuoteRequest model)
        {
            if (ModelState.IsValid)
            {
                var quoteRequest = new QuoteRequest
                {
                    Name = model.Name,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber,
                    Message = model.Message
                };
                _context.QuoteRequests.Add(quoteRequest);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Your message has been sent successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
        public IActionResult About()
        {
            return View();
        }

        public IActionResult Blog() // Capitalized for C# convention
        {
            return View();
        }

        public IActionResult BlogDetails()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(Contact model)
        {
            if (ModelState.IsValid)
            {
                var contact = new Contact
                {
                    Name = model.Name,
                    Email = model.Email,
                    Subject = model.Subject,
                    Message = model.Message
                };
                _context.Contacts.Add(contact);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Your message has been sent successfully!";
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public IActionResult ProjectDetails()
        {
            return View();
        }

        public IActionResult Projects() // Capitalized for C# convention
        {
            return View();
        }

        public IActionResult ServiceDetails()
        {
            return View();
        }

        public IActionResult Services() // Capitalized for C# convention
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