using System;
using System.Collections.Generic;

namespace TaskTrackerApp.Models
{
    public partial class Section
    {
        public Section()
        {
            Tasks = new HashSet<Task>();
        }

        public long Id { get; set; }
        public int IdUser { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
