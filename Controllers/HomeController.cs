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
        private readonly int _idCurrentUser;

        private enum TaskStatuses : byte
        {
            Appointed = 1,
            Performing = 2,
            Pause = 3,
            Completed = 4
        }

        public HomeController(ILogger<HomeController> logger, IStringLocalizer<HomeController> localizer, TrackerDbContext context)
        {
            _logger = logger;
            _localizer = localizer;
            _context = context;
            _idCurrentUser = 1;
        }

        public IActionResult Index()
        {
#warning id user
            TaskTree taskTree = new TaskTree(_idCurrentUser);
            foreach (var item in taskTree.Tasks)
            {
                item.Status = _context.TaskStatuses.Where(x => x.Id == item.IdStatus).Select(x => x.Status).FirstOrDefault() ?? "";
            }
            ViewBag.TaskTree = taskTree;
            ViewBag.Statuses = _context.TaskStatuses.ToList();
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

        [HttpPost]
        public IActionResult RemoveSection(long idSection)
        {
            Section section = _context.Sections.Find(idSection) ?? new Section() { Id = -1 };
            if (section.Id != -1)
            {
                try
                {
                    foreach (Models.Task task in _context.Tasks.Where(x => x.IdSection == section.Id))
                    {
                        task.IdSection = null;
                    }
                    
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

        [HttpPost]
        public IActionResult RemoveTask(long idTask)
        {
            Models.Task task = _context.Tasks.Find(idTask) ?? new Models.Task() { Id = -1 };
            if (task.Id != -1)
            {
                try
                {
                    foreach (Subtask subtask in _context.Subtasks.Where(x => x.IdTask == task.Id))
                    {
                        subtask.IdTask = null;
                    }

                    _context.Tasks.Remove(task);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult AddSection(string nameSection, string descriptionSection)
        {
            if (!string.IsNullOrWhiteSpace(nameSection))
            {
                try
                {
                    _context.Sections.Add(new Section() { IdUser = 1, Title = nameSection, Description = descriptionSection });
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
                
            }
            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public async Task<IActionResult> AddTask(long idSection, string nameTask, string descriptionTask, byte status, DateTime dueDate, string performersList)
        {
            DateTime regDate = DateTime.Now;
            double laboriousness = Math.Round((dueDate - regDate).TotalHours, 2);
            Models.Task task = new Models.Task() 
            { 
                IdSection = idSection,  
                Title = nameTask, 
                Description = descriptionTask, 
                DateRegister = DateTime.Now,
                IdStatus = status,
                PeriodExecution = dueDate,
                Laboriousness = laboriousness,
                PerformersList = performersList
            };
            try
            {
                await _context.AddAsync(task);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> AddSubtask(long idTask, string nameSubtask, string descriptionSubtask, byte status, DateTime dueDate, string performersList)
        {
            DateTime regDate = DateTime.Now;
            double laboriousness = Math.Round((dueDate - regDate).TotalHours, 2);
            Models.Subtask subtask = new Models.Subtask()
            {
                IdTask = idTask,
                Title = nameSubtask,
                Description = descriptionSubtask,
                DateRegister = DateTime.Now,
                IdStatus = status,
                PeriodExecution = dueDate,
                Laboriousness = laboriousness
            };
            try
            {
                await _context.AddAsync(subtask);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult PauseTask(long idTask)
        {
            try
            {
                Models.Task? task = _context.Tasks.FirstOrDefault(x => x.Id == idTask);
                if (task != null)
                {
                    task.IdStatus = ((byte)TaskStatuses.Pause);
                    _context.Update(task);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception)
            {

                throw;
            }
            return new EmptyResult();
        }
        [HttpPost]
        public IActionResult ResumeTask(long idTask)
        {
            try
            {
                Models.Task? task = _context.Tasks.FirstOrDefault(x => x.Id == idTask);
                if (task != null)
                {
                    task.IdStatus = ((byte)TaskStatuses.Performing);
                    _context.Update(task);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception)
            {

                throw;
            }
            return new EmptyResult();
        }
        [HttpPost]
        public IActionResult PauseSubtask(long idSubtask)
        {
            try
            {
                Subtask? subtask = _context.Subtasks.FirstOrDefault(x => x.Id == idSubtask);
                if (subtask != null)
                {
                    subtask.IdStatus = ((byte)TaskStatuses.Pause);
                    _context.Update(subtask);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                
            }
            catch (Exception)
            {

                throw;
            }
            return new EmptyResult();
        }
        [HttpPost]
        public IActionResult ResumeSubtask(long idSubtask)
        {
            try
            {
                Subtask? subtask = _context.Subtasks.FirstOrDefault(x => x.Id == idSubtask);
                if (subtask != null)
                {
                    subtask.IdStatus = ((byte)TaskStatuses.Performing);
                    _context.Update(subtask);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception)
            {

                throw;
            }
            return new EmptyResult();
        }
    }
}