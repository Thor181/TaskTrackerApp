using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Diagnostics;
using TaskTrackerApp.Models;

namespace TaskTrackerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly TrackerDbContext _context;

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, TrackerDbContext context)
        {
            _logger = logger;
            _localizer = localizer;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Models.TaskStatus> model = new List<Models.TaskStatus>(_context.TaskStatuses);
            ViewBag.TaskTree = _context.Subtasks.Include(x => x.IdTaskNavigation).ThenInclude(x => x.IdSectionNavigation).Select(x => new
            {
                IdSection = x.IdTaskNavigation.IdSectionNavigation.Id,
                IdTask = x.IdTaskNavigation.Id,
                IdSubtask = x.Id,
                TitleSection = x.IdTaskNavigation.IdSectionNavigation.Title,
                TitleTask = x.IdTaskNavigation.Title,
                TitleSubtask = x.Title
            });
            return View(model);
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