using DAL.A_DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CourseDAL
{
    public interface ICrousesDAL
    {
        public Task<List<Course>> getCourseAccordingToStudentIDDAL(decimal StudentID);
        public Task<List<Course>> getCourseAccordingToTeachersIDDAL(decimal TeacherID);
        public Task<bool> addCourseDAL(coursDTO Course);
        public Task<bool> UpdateALLCourseDAL(coursDTO Course);
        public Task<bool> DeleteCourseDAL(decimal CourseID);
        public Task<List<Groups>> getGroupeAccordingToCoursesIDDAL(decimal CoursesID);
        public Task<List<Course>> getAllCourseDAL();
        public Task<decimal> addCourseTestDAL(decimal CoursesID, decimal TeacherID);

    }
}
