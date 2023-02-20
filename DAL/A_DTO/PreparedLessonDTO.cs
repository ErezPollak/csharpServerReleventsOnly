using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.A_DTO
{
    public class PreparedLessonDTO
    {
        public decimal LessonId { get; set; }
        public decimal? IndexPreparedLesson { get; set; }
        public bool? IfAlowLesson { get; set; }
        public decimal? CourseId { get; set; }



    }
}
