using System;
using System.Collections.Generic;

namespace TaskTrackerApp.Models
{
    public partial class User
    {
        public User()
        {
            PerformersLists = new HashSet<PerformersList>();
            Sections = new HashSet<Section>();
        }

        public int Id { get; set; }
        public string Login { get; set; } = null!;
        public string Password { get; set; } = null!;

        public virtual ICollection<PerformersList> PerformersLists { get; set; }
        public virtual ICollection<Section> Sections { get; set; }
    }
}
