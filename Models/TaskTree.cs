using Microsoft.Extensions.Localization;
using System.Collections;

namespace TaskTrackerApp.Models
{
    public class TaskTree
    {
        public int IdUser { get; set; }

        public List<Section> Sections { get; set; }
        public List<Task> Tasks { get; set; }
        public List<Subtask> Subtasks { get; set; }

        public TaskTree(int idUser)
        {
            IdUser = idUser;
            using (TrackerDbContext db = new())
            {
                Sections = new List<Section>(db.Sections.Where(x => x.IdUser == idUser));
                Tasks = new List<Task>(db.Tasks.Where(x => x.IdSectionNavigation.IdUser == idUser));
                Subtasks = new List<Subtask>(db.Subtasks.Where(x => x.IdTaskNavigation.IdSectionNavigation.IdUser == idUser));
            }       
        }
    }
}
