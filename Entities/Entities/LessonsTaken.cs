using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class LessonsTaken
    {
        public decimal LessonsTakenId { get; set; }
        public DateTime? DateAndTime { get; set; }
        public decimal? GroupId { get; set; }
        public decimal? LessonId { get; set; }

        public virtual Groups Group { get; set; }
        public virtual PreparedLesson Lesson { get; set; }
    }
}
