using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Entities.Entities
{
    public partial class LearningFile
    {
        public decimal FileId { get; set; }
        public string TypeFile { get; set; }
        public string DescriptionFile { get; set; }
        public string SrcDrivFile { get; set; }
        public string SrcPdfFile { get; set; }
        public decimal? LessonId { get; set; }

        public virtual PreparedLesson Lesson { get; set; }
    }
}
