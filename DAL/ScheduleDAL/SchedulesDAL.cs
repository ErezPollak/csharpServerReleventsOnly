using DAL.A_DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DAL.CourseToClassDAL;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace DAL.ScheduleDAL
{
    public class SchedulesDAL : IScheduleDAL
    {
        private My_Virtua_lSchoolContext _context;
        public SchedulesDAL(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }
        public SchedulesDAL()
        {
        } 
        
        public async Task<bool> addScheduleCourseDAL(Schedule Schedule)
        {
            var resScheduleCourse = await _context.Schedule.AddAsync(Schedule);
            await _context.SaveChangesAsync();
            if (resScheduleCourse != null)
                return true;
            return false;
        }

       

        public async Task<bool> DeleteScheduleCourseDAL(decimal ScheduleID)
        {
            try
            {
                var resSchedule = await _context.Schedule.Where(x => x.ScheduleId.Equals(ScheduleID)).FirstOrDefaultAsync();
                var resScheduleEnd = _context.Schedule.Remove(resSchedule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Schedule>> getScheduleCourseAccordingToGoupIDDAL(decimal groupID)
        {
            return await _context.Schedule.Where(x => x.CoursesToClsss.IdGroup == groupID).Select(x => x).ToListAsync();
        }

        public async Task<Schedule> getScheduleCourseAccordingToIDDAL(decimal ScheduleID)
        {
            return await _context.Schedule.Where(x => x.ScheduleId == ScheduleID).FirstOrDefaultAsync();
        }


        public async Task<List<Schedule>> getScheduleCourseAccordingToStudentIDDAL(string StudentID)
        {
            Student student = await _context.Student.Where(x => x.IdentitiyNumber == StudentID).FirstOrDefaultAsync();
            return await _context.Schedule.Where(x => x.CoursesToClsss.IdGroup == student.GroupId).Select(x => x).ToListAsync();
        }

        public async Task<List<Schedule>> getScheduleCourseAccordingToTeacherIDDAL(decimal techerID)
        {
            
            var courses = await _context.Course.Where(x => x.TeacherId == techerID).Select(x => x).ToListAsync();
            //var coursesToClasses = await _context.CoursesToClsss.Where(ctc => courses.Any(course => course.CoueseId == ctc.CourseId)).Select(x => x).ToListAsync();
            var coursesToClasses = await _context.CoursesToClsss.Where(ctc => true).Select(x => x).ToListAsync();
            var releventCoursesToClasses = new List<CoursesToClsss>();
            foreach (var ctc in coursesToClasses)
            {
                foreach (var course in courses)
                {
                    if (ctc.CourseId == course.CoueseId)
                    {
                        releventCoursesToClasses.Add(ctc);
                    }
                }
            }
            var schedule = await _context.Schedule.Where(sch => true).Select(x => x).ToListAsync();
            var releventSchedule = new List<Schedule>();
            foreach (var sch in schedule)
            {
                foreach (var ctc in releventCoursesToClasses)
                {
                    if (ctc.CoursesToClsssId == sch.CoursesToClsssId)
                    {
                        var s = sch;
                        s.CoursesToClsss = null;
                        releventSchedule.Add(s);
                    }
                }
            }

            return releventSchedule;
        }

        public async Task<List<Schedule>> getScheduleCourse()
        {
            return await _context.Schedule.Where(x => true).Select(x => x).ToListAsync();
        }

        public async Task<bool> UpdateScheduleCourseDAL(Schedule Schedule)
        {
            try
            {
                var resSchedule = await _context.Schedule.Where(x => x.ScheduleId.Equals(Schedule.ScheduleId)).FirstOrDefaultAsync();
                resSchedule.numberDayOfWeek = Schedule.numberDayOfWeek;
                resSchedule.ScheduleHourIndex = Schedule.ScheduleHourIndex;
                resSchedule.CoursesToClsssId = Schedule.CoursesToClsssId;
                //var resScheduleEnd = _context.Schedule.AddAsync(resSchedule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
