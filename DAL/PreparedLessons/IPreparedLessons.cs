using DAL.A_DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PreparedLessons
{
    public interface IPreparedLessons
    {
        public Task<bool> addPreparedLessonDAL(PreparedLesson preparedLesson);
        public Task<bool> UpdatepreparedLessonDAL(PreparedLesson preparedLesson);
        public Task<bool> DeletePreparedLessonDAL(decimal preparedLessonID);
        public Task<PreparedLesson> getPreparedLessonAccordingToIDDAL(decimal preparedLessonID);
        public Task<List<PreparedLesson>> getListPreparedLessonsAccordingToCourseIDToStusentDAL(decimal CourseID, string StudentID);
        public Task<List<PreparedLessonDTO>> getListPreparedLessonsAccordingToCourseIDToGroupDAL(decimal CourseID, decimal Group);
    }
}
