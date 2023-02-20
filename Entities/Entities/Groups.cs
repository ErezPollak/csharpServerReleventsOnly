using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class Groups
    {
        public Groups()
        {
            CoursesToClsss = new HashSet<CoursesToClsss>();
            LessonsTaken = new HashSet<LessonsTaken>();
            Student = new HashSet<Student>();
        }

        public decimal GroupsId { get; set; }
        public string GroupName { get; set; }
        public decimal? rankGroup { get; set; }

        public virtual ICollection<CoursesToClsss> CoursesToClsss { get; set; }
        public virtual ICollection<LessonsTaken> LessonsTaken { get; set; }
        public virtual ICollection<Student> Student { get; set; }
    }
}
