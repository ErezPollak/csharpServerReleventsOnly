using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class CoursesToClsss
    {
        public CoursesToClsss()
        {
            PreparedLesson = new HashSet<PreparedLesson>();
            Schedule = new HashSet<Schedule>();
            presenceInLessons = new HashSet<presenceInLessons>();
        }

        public decimal CoursesToClsssId { get; set; }
        public decimal? CourseId { get; set; }
        public decimal? IdGroup { get; set; }

        public virtual Course Course { get; set; }
        public virtual Groups IdGroupNavigation { get; set; }
        public virtual ICollection<PreparedLesson> PreparedLesson { get; set; }
        public virtual ICollection<Schedule> Schedule { get; set; }
        public virtual ICollection<presenceInLessons> presenceInLessons { get; set; }
    }
}
