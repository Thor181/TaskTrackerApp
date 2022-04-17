using System;
using System.Collections.Generic;

namespace TaskTrackerApp.Models
{
    public partial class TaskStatus
    {
        public TaskStatus()
        {
            Subtasks = new HashSet<Subtask>();
            Tasks = new HashSet<Task>();
        }

        public byte Id { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<Subtask> Subtasks { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
