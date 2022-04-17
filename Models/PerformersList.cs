using System;
using System.Collections.Generic;

namespace TaskTrackerApp.Models
{
    public partial class PerformersList
    {
        public long Id { get; set; }
        public int IdUser { get; set; }
        public long IdTask { get; set; }

        public virtual Task IdTaskNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
