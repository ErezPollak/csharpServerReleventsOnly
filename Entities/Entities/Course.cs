using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class Course
    {
        public Course()
        {
            CoursesToClsss = new HashSet<CoursesToClsss>();
        }

        public decimal CoueseId { get; set; }
        public string CourseName { get; set; }
        public string ImgCourse { get; set; }
        public decimal? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<CoursesToClsss> CoursesToClsss { get; set; }
    }
}
