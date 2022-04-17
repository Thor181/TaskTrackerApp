using Microsoft.Extensions.Localization;

namespace TaskTrackerApp.Models
{
    public class TaskTree
    {
        public int IdUser { get; set; }

        public int IdSection { get; set; }
        public int IdTask { get; set; }
        public int IdSubTask { get; set; }

        public string TitleSection { get; set; }
        public string TitleTask { get; set; }
        public string TitleSubtask { get; set; }

        public string DescriptionSection { get; set; }
        public string DescriptionTask { get; set; }
        public string DescriptionSubtask { get; set; }

        public TaskTree(int idSection, int idTask, int idSubtask, IStringLocalizer localizer)
        {
            IdSection = IdSection;
            IdTask = IdTask;
            IdSubTask = idSubtask;

            using (TaskTrackerApp.Models.TrackerDbContext db = new())
            {
                
                IdUser = db.Sections.Where(x => x.Id == idSection).Select(x => x.IdUser).FirstOrDefault();
                TitleSection = db.Sections.Where(x => x.Id == idSection).Select(x => x.Title).FirstOrDefault() ?? "";

            }
        }
    }
}
