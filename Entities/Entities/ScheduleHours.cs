using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class ScheduleHours
    {
        public ScheduleHours()
        {
            Schedule = new HashSet<Schedule>();
        }

        public decimal ScheduleHoursIndex { get; set; }
        public DateTime? TimeBeginning { get; set; }
        public DateTime? TimeEnd { get; set; }

        public virtual ICollection<Schedule> Schedule { get; set; }
    }
}
