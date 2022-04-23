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
            void add()
            {
                _context.Add(new Section() { Title = $"newSection {new Random().Next(100)}", Description = "newDescr", IdUser = 1 });
                _context.SaveChanges();
                _context.Add(new Models.Task() { Title = "newTask", IdSection = _context.Sections.OrderBy(x => x.Id).Select(x => x.Id).Last(), Description = "newDescr", DateRegister = DateTime.Now, IdStatus = 2, Laboriousness = 8, PeriodExecution = DateTime.Now });
                _context.SaveChanges();
            }
            //add();
#warning id user
            ViewBag.TaskTree = _context.Users.Select(x => new TaskTree(x.Id)).First();
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

        public IActionResult RemoveSection(long idSection)
        {
            Section section = _context.Sections.Find(idSection) ?? new Section() { Id = -1 };
            if (section.Id != -1)
            {
                try
                {
                    _context.Sections.Remove(section);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
    }
}