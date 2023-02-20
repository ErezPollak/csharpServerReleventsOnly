using DAL.A_DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CourseToClassDAL
{
    public interface ICourseToClassDAL
    {
        public Task<List<CuorsesViewDTO>> getListCourseToClassAccordingToGroupIDDAL(decimal GroupID);
        public Task<CoursesToClsss> getCourseToClassAccordingToIDDAL(decimal CourseToClassID);
        public Task<bool> addCourseToClassDAL(decimal GroupID, decimal CourseID);
        public Task<bool> addCourseToClassDAL(List<string> CourseName, decimal CourseID);
        public Task<bool> addCourseToClassDAL(CoursesToClsss Course);
        public Task<bool> DeleteCourseToClassIDDAL(decimal CourseToClassID);
        public Task<decimal> addCourseToClassTestDAL(CourseTestDTO CourseTest);
        public Task<List<CoursesToClsss>> getCourseToClassTestAccordingToGroupIDDAL(decimal GroupID);
        public Task<bool> addCourseToClass2API(List<string> CourseName, decimal CourseID);
        public Task<List<CoursesToClsss>> getListCourseToClassAccordingToCourseIDDAL(decimal courseId);
    }
}
