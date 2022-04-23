using System;
using System.Collections.Generic;

namespace TaskTrackerApp.Models
{
    public partial class Subtask
    {
        public long Id { get; set; }
        public long? IdTask { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime DateRegister { get; set; }
        public byte IdStatus { get; set; }
        public int Laboriousness { get; set; }
        public DateTime PeriodExecution { get; set; }
        public DateTime? DateCompletion { get; set; }
        public DateTime? ActualExecutionTime { get; set; }

        public virtual TaskStatus IdStatusNavigation { get; set; } = null!;
        public virtual Task IdTaskNavigation { get; set; } = null!;
    }
}
