using Builders_Deck.Data;
using Microsoft.AspNetCore.Mvc;

namespace Builders_Deck.Controllers
{
    public class PageController : Controller
    {
            private readonly ApplicationDbContext _context;

            public PageController(ApplicationDbContext context)
            {
                _context = context;
            }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Home()
        {
            var projects = _context.Projects
                .OrderByDescending(p => p.CompletionDate)
                .Take(5) // Display the latest 5 projects
                .ToList();

            return View(projects);
        }

        public IActionResult Search(string location, decimal? minBudget, decimal? maxBudget)
        {
            var contractors = _context.Contractors.AsQueryable();

            if (!string.IsNullOrEmpty(location))
                contractors = contractors.Where(c => c.Location.Contains(location));

            if (minBudget.HasValue)
                contractors = contractors.Where(c => c.Budget >= minBudget);

            if (maxBudget.HasValue)
                contractors = contractors.Where(c => c.Budget <= maxBudget);

            return View(contractors.ToList());
        }
    }
}
