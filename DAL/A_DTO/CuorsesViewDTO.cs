using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.A_DTO
{
    public class CuorsesViewDTO
    {
        public decimal CoursesToClsssId { get; set; }
        public decimal? IdGroup { get; set; }
        public decimal? CoueseId { get; set; }
        public string CourseName { get; set; }
        public string ImgCourse { get; set; }
        public decimal? TeacherId { get; set; }

        public CuorsesViewDTO(decimal coursesToClsssId, decimal? idGroup, decimal coueseId, string courseName, string imgCourse, decimal? teacherId)
        {
            CoursesToClsssId = coursesToClsssId;
            IdGroup = idGroup;
            CoueseId = coueseId;
            CourseName = courseName;
            ImgCourse = imgCourse;
            TeacherId = teacherId;
        }

        public CuorsesViewDTO()
        {
        }

       

       
    }
}
