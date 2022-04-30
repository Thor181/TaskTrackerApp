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
            Initialize();
            return View();
        }

        private void Initialize()
        {
            if (_context.Users.Count(x => x.Id > -1) == 0)
            {
                _context.Users.Add(new Models.User() { Id = 1, Login = "admin", Password = "123456" });
                _context.SaveChanges();
            }
            TaskTree taskTree = new TaskTree(_idCurrentUser);
            taskTree.Tasks.ForEach(x => x.Status = _context.TaskStatuses.Where(t => t.Id == x.IdStatus).Select(t => t.Status).FirstOrDefault()); //add string (not id) status to model
            taskTree.Subtasks.ForEach(x => x.Status = _context.TaskStatuses.Where(t => t.Id == x.IdStatus).Select(t => t.Status).FirstOrDefault()); //add string (not id) status to model
            ViewBag.TaskTree = taskTree;
            ViewBag.Statuses = _context.TaskStatuses.ToList();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddSection(string nameSection, string descriptionSection)
        {
            if (string.IsNullOrWhiteSpace(nameSection)) return NoContent();

            try
            {
                _context.Sections.Add(new Section()
                {
                    IdUser = _idCurrentUser,
                    Title = nameSection,
                    Description = descriptionSection
                });
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult AddTask(long idSection, string nameTask, string descriptionTask, byte status, DateTime dueDate, string performersList)
        {
            if (string.IsNullOrWhiteSpace(nameTask) || dueDate < new DateTime(1900, 1, 1)) return NoContent();

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
                _context.Add(task);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult AddSubtask(long idTask, string nameSubtask, string descriptionSubtask, byte status, DateTime dueDate, string performersList)
        {
            if (string.IsNullOrWhiteSpace(nameSubtask) || dueDate < new DateTime(1900, 1, 1)) return NoContent();

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
                _context.Add(subtask);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult EditSection(long idSection, string nameSection, string descriptionSection)
        {
            if (string.IsNullOrWhiteSpace(nameSection)) return NoContent();

            try
            {
                Section section = _context.Sections.Find(idSection) ?? new Section() { IdUser = -1 };
                if (section.IdUser == -1) return RedirectToAction(nameof(Index));
                section.Title = nameSection;
                section.Description = descriptionSection;
                _context.Update(section);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }


            return RedirectToAction(nameof(Index));

        }
        [HttpPost]
        public IActionResult EditTask(string nameTask, string descriptionTask, long idTask, byte status, DateTime dueDate, string performersList)
        {
            if (string.IsNullOrWhiteSpace(nameTask) || dueDate < new DateTime(1900, 1, 1)) return NoContent();
            try
            {
                Models.Task task = _context.Tasks.Find(idTask) ?? new Models.Task() { IdSection = -1 };
                if (task.IdSection == -1) return RedirectToAction(nameof(Index));
                task.Title = nameTask;
                task.Description = descriptionTask;
                task.IdStatus = status;
                task.PeriodExecution = dueDate;
                _context.Update(task);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult EditSubtask(string nameSubtask, string descriptionSubtask, long idSubtask, byte status, DateTime dueDate)
        {
            if (string.IsNullOrWhiteSpace(nameSubtask) || dueDate < new DateTime(1900, 1, 1)) return NoContent();
            try
            {
                Subtask subtask = _context.Subtasks.Find(idSubtask) ?? new Subtask() { IdTask = -1 };
                if (subtask.IdTask == -1) return RedirectToAction(nameof(Index));
                subtask.Title = nameSubtask;
                subtask.Description = descriptionSubtask;
                subtask.IdStatus = status;
                subtask.PeriodExecution = dueDate;
                _context.Update(subtask);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction(nameof(Index));
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
                        task.IdSection = null; //cascade deleting
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
                        subtask.IdTask = null; //cascade deleting
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
        public IActionResult RemoveSubtask(long idSubtask)
        {
            Subtask subtask = _context.Subtasks.Find(idSubtask) ?? new Models.Subtask() { Id = -1 };
            if (subtask.Id != -1)
            {
                try
                {
                    _context.Subtasks.Remove(subtask);
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
            return NoContent();
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
                if (subtask == null) return NoContent();

                subtask.IdStatus = ((byte)TaskStatuses.Pause);
                _context.Update(subtask);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public IActionResult ResumeSubtask(long idSubtask)
        {
            try
            {
                Subtask? subtask = _context.Subtasks.FirstOrDefault(x => x.Id == idSubtask);
                if (subtask == null) return NoContent();

                subtask.IdStatus = ((byte)TaskStatuses.Performing);
                _context.Update(subtask);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public IActionResult CompletTask(long idTask)
        {
            try
            {
                Models.Task? task = _context.Tasks.FirstOrDefault(x => x.Id == idTask);
                if (task != null)
                {
                    if (task.IdStatus == ((byte)TaskStatuses.Appointed) || task.IdStatus == ((byte)TaskStatuses.Completed)) return NoContent();
                    task.IdStatus = ((byte)TaskStatuses.Completed);
                    var subtask = _context.Subtasks.Where(x => x.IdTask == idTask).ToList();
                    subtask.ForEach(x => x.IdStatus = ((byte)TaskStatuses.Completed));
                    _context.Update(task);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }

            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }
        [HttpPost]
        public IActionResult CompletSubtask(long idSubtask)
        {
            try
            {
                Subtask? subtask = _context.Subtasks.FirstOrDefault(x => x.Id == idSubtask);
                if (subtask != null)
                {
                    if (subtask.IdStatus == ((byte)TaskStatuses.Appointed) || subtask.IdStatus == ((byte)TaskStatuses.Completed)) return NoContent();

                    subtask.IdStatus = ((byte)TaskStatuses.Completed);
                    subtask.DateCompletion = DateTime.Now;
                    subtask.ActualExecutionTime = Service.DateTimeController.CalculateDifference(subtask.DateRegister);
                    _context.Update(subtask);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception)
            {
                throw;
            }
            return NoContent();
        }
    }
}