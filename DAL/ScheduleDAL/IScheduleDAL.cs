using DAL.A_DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ScheduleDAL
{
   public  interface IScheduleDAL
    {
        public Task<bool> DeleteScheduleCourseDAL(decimal ScheduleID);
        public Task<bool> addScheduleCourseDAL(Schedule Schedule);
        public Task<bool> UpdateScheduleCourseDAL(Schedule Schedule);
        public Task<List<Schedule>> getScheduleCourseAccordingToStudentIDDAL(string StudentID);
        public Task<List<Schedule>> getScheduleCourseAccordingToTeacherIDDAL(decimal techerID);
        public Task<List<Schedule>> getScheduleCourseAccordingToGoupIDDAL(decimal groupID);
        public Task<Schedule> getScheduleCourseAccordingToIDDAL(decimal ScheduleID);
        public Task<List<Schedule>> getScheduleCourse();
    }
}
