using DAL.A_DTO;
using DAL.CourseToClassDAL;
using DAL.ScheduleDAL;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CourseTestsDTO
{
    public class CourseTestsDTO : ICourseTestDTO
    {
        private My_Virtua_lSchoolContext _context;
        public CourseTestsDTO(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }
        
        public async Task<List<CourseTestDTO>> getCourseTestAccordingTostudentIDDAL(string studentID)
        {
            Student student = await _context.Student.Where(x => x.IdentitiyNumber == studentID).FirstOrDefaultAsync();
            decimal groupStudentID = (decimal)student.GroupId;
            CourseToClassesDAL courseToClassDAL = new CourseToClassesDAL();
            List<CoursesToClsss> lstCoursesToClsss = courseToClassDAL.getCourseToClassTestAccordingToGroupIDDAL(groupStudentID).Result;
            List<Schedule> lstSchedule = new List<Schedule>();
            foreach (var item1 in lstCoursesToClsss)
            {
                List<Schedule> lstScheduleCopy = await _context.Schedule.Where(x => x.CoursesToClsssId == item1.CoursesToClsssId).Select(x => x).ToListAsync();
                foreach (var item2 in lstScheduleCopy)
                {
                    lstSchedule.Add(item2);
                }
            }
            List<CourseTestDTO> lstCourseTestDTO = new List<CourseTestDTO>();
            foreach (var item1 in lstCoursesToClsss)
            {
                CourseTestDTO courseTestDTO = new CourseTestDTO() { CourseID = (decimal)item1.CourseId, groupID = groupStudentID, TeacherID = (decimal)item1.Course.TeacherId };
                foreach (var item2 in lstSchedule)
                {
                    if (item2.CoursesToClsssId == item1.CoursesToClsssId)
                    {
                        courseTestDTO.numberDayOfWeek = (decimal)item2.numberDayOfWeek;
                        courseTestDTO.ScheduleHoursIndex = (decimal)item2.ScheduleHourIndex;
                    }
                }
                lstCourseTestDTO.Add(courseTestDTO);
            }
            return lstCourseTestDTO;
        }

        public async Task<List<CourseTestDTO>> getCourseTestAccordingToteacherIDDAL(decimal teacherID)
        {
            List<CoursesToClsss> lstCoursesToClsss = await _context.CoursesToClsss.Where(x => x.Course.TeacherId == teacherID).Select(x => x).ToListAsync() ;
            List<Schedule> lstSchedule = new List<Schedule>();
            foreach (var item1 in lstCoursesToClsss)
            {
                List<Schedule> lstScheduleCopy = await _context.Schedule.Where(x => x.CoursesToClsssId == item1.CoursesToClsssId).Select(x => x).ToListAsync();
                foreach (var item2 in lstScheduleCopy)
                {
                    lstSchedule.Add(item2);
                }
            }
            List<CourseTestDTO> lstCourseTestDTO = new List<CourseTestDTO>();
            foreach (var item1 in lstCoursesToClsss)
            {
                CourseTestDTO courseTestDTO = new CourseTestDTO() { CourseID = (decimal)item1.CourseId, groupID = (decimal)item1.IdGroup, TeacherID = (decimal)item1.Course.TeacherId };
                foreach (var item2 in lstSchedule)
                {
                    if (item2.CoursesToClsssId == item1.CoursesToClsssId)
                    {
                        courseTestDTO.numberDayOfWeek = (decimal)item2.numberDayOfWeek;
                        courseTestDTO.ScheduleHoursIndex = (decimal)item2.ScheduleHourIndex;
                    }
                }
                lstCourseTestDTO.Add(courseTestDTO);
            }
            return lstCourseTestDTO;
        }

        public async Task<bool> addCourseTestDAL(CourseTestDTO courseTestDTO)
        {
            SchedulesDAL scheduleDAL = new SchedulesDAL();
            CourseToClassesDAL courseToClassDAL = new CourseToClassesDAL();
            Task<decimal> CourseToClassID = courseToClassDAL.addCourseToClassTestDAL(courseTestDTO);
            Schedule schedule = new Schedule() { numberDayOfWeek = courseTestDTO.numberDayOfWeek, ScheduleHourIndex = courseTestDTO.ScheduleHoursIndex, CoursesToClsssId = CourseToClassID.Result };
            Task<bool> res = scheduleDAL.addScheduleCourseDAL(schedule);
            if (res.Result)
                return true;
            return false;
        }

     
    }
}
