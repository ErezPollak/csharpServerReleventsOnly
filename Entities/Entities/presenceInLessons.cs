using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class presenceInLessons
    {
        public decimal presenceInLessonsId { get; set; }
        public DateTime? DateToday { get; set; }
        public decimal? StudentId { get; set; }
        public decimal? CoursesToClsssId { get; set; }
        public DateTime? TimeBeginning { get; set; }
        public DateTime? TimeEnd { get; set; }

        public virtual CoursesToClsss CoursesToClsss { get; set; }
        public virtual Student Student { get; set; }
    }
}
