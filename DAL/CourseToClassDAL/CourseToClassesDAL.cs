using DAL.A_DTO;
using DAL.CourseDAL;
using DAL.PreparedLessons;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.CourseToClassDAL
{
    public class CourseToClassesDAL : ICourseToClassDAL
    {
        private My_Virtua_lSchoolContext _context;
        public CourseToClassesDAL(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }
        public CourseToClassesDAL()
        {

        }
        public async Task<bool> addCourseToClassDAL(decimal GroupID, decimal CourseID)
        {
            var resCourseToClass = await _context.CoursesToClsss.AddAsync(new CoursesToClsss() { CourseId = CourseID, IdGroup = GroupID });
            await _context.SaveChangesAsync();
            if (resCourseToClass != null)
                return true;
            return false;
        }
        public async Task<bool> addCourseToClassDAL(CoursesToClsss Course)
        {
            var resCourseToClass = await _context.CoursesToClsss.AddAsync(Course);
            await _context.SaveChangesAsync();
            if (resCourseToClass != null)
                return true;
            return false;
        }
        
        
        public async Task<bool> addCourseToClass2API(List<string> CourseName, decimal GroupID)
        {
            //foreach (var item in CourseName)
            //{
            //    var curse = await _context.Course.Where(x => x.CourseName == item).Select(x => x).ToListAsync();
            //    var resCourseToClass = new CoursesToClsss { CourseId = curse. }
            //    var resCourseToClass = await _context.CoursesToClsss.AddAsync(Course);
            //    _context.SaveChangesAsync();
            //}
            var courseIdList = await _context.Course.Where(x => CourseName.Contains(x.CourseName)).ToListAsync();
            for (int i = 0; i < courseIdList.Count(); i++)
            {
                CoursesToClsss corse2Class = new CoursesToClsss();
                corse2Class.CourseId = courseIdList[i].CoueseId;
                corse2Class.IdGroup = GroupID;
                await _context.CoursesToClsss.AddAsync(corse2Class);
                try
                {

                    var isOk= await _context.SaveChangesAsync()>=0;
                    {
                        if(isOk==true)
                        {

                        }
                    }
                }catch(Exception ex)
                {

                }
            }
            return true;
        }

        public async Task<decimal> addCourseToClassTestDAL(CourseTestDTO CourseTest1)
        {
            ICrousesDAL courses = new CoursesDAL();
            Task<decimal> cours = courses.addCourseTestDAL(CourseTest1.CourseID, CourseTest1.TeacherID);
            CoursesToClsss coursesToClsss=  new CoursesToClsss() { CourseId = CourseTest1.CourseID, IdGroup = CourseTest1.groupID };
            Task<bool> res = this.addCourseToClassDAL(coursesToClsss);
            return coursesToClsss.CoursesToClsssId;
        }

        public async Task<bool> DeleteCourseToClassIDDAL(decimal CourseToClassID)
        {
            try
            {
                List<presenceInLessons> lstlPreparedLesson = await _context.presenceInLessons.Where(x => x.CoursesToClsssId == CourseToClassID).Select(x => x).ToListAsync();
                List<Schedule> lstSchedule = await _context.Schedule.Where(x => x.CoursesToClsssId == CourseToClassID).Select(x => x).ToListAsync();
                if (lstSchedule != null)
                {
                    foreach (var item in lstSchedule)
                    {
                        //לעשות ברגע שיהיה לי מחיקה לשעה במערכת
                    }
                }
                if (lstlPreparedLesson != null)
                {
                    foreach (var item in lstlPreparedLesson)
                    {
                        PreparedLessonss preparedLessonss = new PreparedLessonss();
                        preparedLessonss.DeletePreparedLessonDAL(item.presenceInLessonsId);
                    }
                }
                var resCourseToClass = await _context.CoursesToClsss.Where(x => x.CoursesToClsssId.Equals(CourseToClassID)).FirstOrDefaultAsync();
                _context.CoursesToClsss.Remove(resCourseToClass);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public async Task<List<CuorsesViewDTO>> getListCourseToClassAccordingToGroupIDDAL(decimal GroupID)
        {
            var lstCourseToClass = await (from c in _context.CoursesToClsss
                                          join cc in _context.Course
                                          on c.CourseId equals cc.CoueseId
                                          where c.IdGroup == GroupID
                                          select new CuorsesViewDTO
                                          {
                                              CourseName = cc.CourseName,
                                              CoueseId = c.CourseId,
                                              CoursesToClsssId = c.CoursesToClsssId,
                                          }).ToListAsync();

            //List<CoursesToClsss> lstCourseToClass = await _context.CoursesToClsss.Where(x => x.IdGroup == GroupID).Select(x => x).ToListAsync();

            return lstCourseToClass;
        }
        
        
        
        public async Task<List<CoursesToClsss>> getListCourseToClassAccordingToCourseIDDAL(decimal courseId)
        {
            var lstCorseToClass = await _context.CoursesToClsss.Where(ctc => ctc.CourseId == courseId).ToListAsync();
            return lstCorseToClass;
        }


        public async Task<List<CoursesToClsss>> getCourseToClassTestAccordingToGroupIDDAL(decimal GroupID )
        {
            return await _context.CoursesToClsss.Where(x => x.IdGroup == GroupID && x.Course.CourseName.IndexOf("The test in")!=-1).Select(x => x).ToListAsync();
     
        }

        public async Task<CoursesToClsss> getCourseToClassAccordingToIDDAL(decimal CourseToClassID)
        {
           return  await _context.CoursesToClsss.Where(x => x.CoursesToClsssId.Equals(CourseToClassID)).FirstOrDefaultAsync();
        }
        public async Task<bool> addCourseToClassDAL(List<string> CourseName, decimal GroupID)
        {
            //1. ??????????????????????????????????????

            return true;
        }

    }
}
