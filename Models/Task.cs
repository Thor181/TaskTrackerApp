using System;
using System.Collections.Generic;

namespace TaskTrackerApp.Models
{
    public partial class Task
    {
        public Task()
        {
            //PerformersLists = new HashSet<PerformersList>();
            Subtasks = new HashSet<Subtask>();
        }

        public long Id { get; set; }
        public long? IdSection { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DateRegister { get; set; }
        public byte IdStatus { get; set; }
        public int Laboriousness { get; set; }
        public DateTime PeriodExecution { get; set; }
        public DateTime? DateCompletion { get; set; }
        public DateTime? ActualExecutionTime { get; set; }
        public string? PerformersList { get; set; }


        public virtual Section IdSectionNavigation { get; set; } = null!;
        public virtual TaskStatus IdStatusNavigation { get; set; } = null!;
        //public virtual ICollection<PerformersList> PerformersLists { get; set; }

        public virtual ICollection<Subtask> Subtasks { get; set; }
    }
}
