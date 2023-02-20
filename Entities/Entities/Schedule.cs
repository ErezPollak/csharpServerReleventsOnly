using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class Schedule
    {
        public decimal ScheduleId { get; set; }
        public decimal? numberDayOfWeek { get; set; }
        public decimal? ScheduleHourIndex { get; set; }
        public decimal? CoursesToClsssId { get; set; }

        public virtual CoursesToClsss CoursesToClsss { get; set; }
        public virtual ScheduleHours ScheduleHourIndexNavigation { get; set; }
    }
}
