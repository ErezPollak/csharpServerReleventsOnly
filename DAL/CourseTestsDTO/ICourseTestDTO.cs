using DAL.A_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CourseTestsDTO
{
    public interface ICourseTestDTO
    {
        public Task<bool> addCourseTestDAL(CourseTestDTO courseTestDTO);
        public Task<List<CourseTestDTO>> getCourseTestAccordingTostudentIDDAL(string studentID);
        public Task<List<CourseTestDTO>> getCourseTestAccordingToteacherIDDAL(decimal teacherID);
    }
}
