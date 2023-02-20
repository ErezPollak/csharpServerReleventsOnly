using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.A_DTO
{
    public class coursDTO
    {
        public decimal CoueseId { get; set; }
        public string CourseName { get; set; }
        public string ImgCourse { get; set; }
        public decimal? TeacherId { get; set; }
        public List<DocumentDto> Document { get; set; }
    }
}
