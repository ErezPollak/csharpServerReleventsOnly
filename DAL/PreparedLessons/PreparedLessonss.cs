
using AutoMapper;
using DAL.A_DTO;
using DAL.LearningFiles;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PreparedLessons
{
    public class PreparedLessonss : IPreparedLessons
    {

        private My_Virtua_lSchoolContext _context;
        private readonly IMapper _mapper;
        public PreparedLessonss(My_Virtua_lSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public PreparedLessonss()
        {

        }

        public async Task<List<PreparedLessonDTO>> getListPreparedLessonsAccordingToCourseIDToGroupDAL(decimal CourseID, decimal Group)
        {

            //CoursesToClsss lstcoursesToClssses = null;
            List<PreparedLessonDTO> lstPreparedLesson = new List<PreparedLessonDTO>();
            try
            {
          
                lstPreparedLesson = _mapper.Map<List<PreparedLessonDTO>>(await _context.PreparedLesson.Where(x => x.CourseId == CourseID).Select(x => x).ToListAsync());
                

            }
            catch (Exception e)
            {

            }
            return lstPreparedLesson;

        }
        public async Task<bool> addPreparedLessonDAL(PreparedLesson preparedLesson)
        {
            try
            {
                var resPreparedLesson = _context.PreparedLesson.AddAsync(preparedLesson);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

            // if (resPreparedLesson != null)
            //     return true;
            // return false;
        }

        public async Task<bool> DeletePreparedLessonDAL(decimal preparedLessonID)
        {
            try
            {
                LearningFiless LearningFile = new LearningFiless();
                var resLearningFiles = await _context.LearningFile.Where(x => x.LessonId == preparedLessonID).Select(x => x).ToListAsync();
                foreach (var item in resLearningFiles)
                {
                    LearningFile.DeleteFileDAL(item.FileId);
                }
                var respreparedLesson = await _context.PreparedLesson.Where(x => x.LessonId.Equals(preparedLessonID)).FirstOrDefaultAsync();
                var respreparedLessonEnd = _context.PreparedLesson.Remove(respreparedLesson);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<PreparedLesson>> getListPreparedLessonsAccordingToCourseIDToStusentDAL(decimal CourseID, string StudentID)
        {
            CoursesToClsss lstcoursesToClssses = new CoursesToClsss();
            List<PreparedLesson> lstPreparedLesson = new List<PreparedLesson>();
            lstPreparedLesson = null;
            Groups GroupStudent = new Groups();
            GroupStudent = await _context.Student.Where(x => x.IdentitiyNumber == StudentID).Select(x => x.Group).FirstOrDefaultAsync();
            lstcoursesToClssses = await _context.CoursesToClsss.Where(x => x.CourseId == CourseID && x.IdGroup == GroupStudent.GroupsId).Select(x => x).FirstOrDefaultAsync();
            foreach (var item in _context.PreparedLesson)
            {
                if (item.CourseId == lstcoursesToClssses.CoursesToClsssId)
                {
                    lstPreparedLesson.Add(item);
                }
            }
            return lstPreparedLesson;
        }
        public async Task<List<PreparedLesson>> getListPreparedLessonsAccordingToGroupIDToTeacherDAL(decimal GroupID, decimal TeacherID)
        {
            List<Course> lstCourse = new List<Course>();
            List<CoursesToClsss> lstcoursesToClssses = null;
            List<PreparedLesson> resPreparedLesson = new List<PreparedLesson>();
            foreach (var item in _context.Course)
            {
                if (item.TeacherId == TeacherID)
                {
                    lstCourse.Add(item);
                }
            }
            foreach (var item in lstCourse)
            {
                lstcoursesToClssses.Add(await _context.CoursesToClsss.Where(x => x.CourseId == item.CoueseId && x.IdGroup == GroupID).Select(x => x).FirstOrDefaultAsync());
            }
            foreach (var item in lstcoursesToClssses)
            {
                resPreparedLesson.Add(await _context.PreparedLesson.Where(x => x.CourseId == item.CourseId).Select(x => x).FirstOrDefaultAsync());
            }
            return resPreparedLesson;
        }
        public async Task<PreparedLesson> getPreparedLessonAccordingToIDDAL(decimal preparedLessonID)
        {
            var resPreparedLesson = await _context.PreparedLesson.Where(x => x.LessonId == preparedLessonID).FirstOrDefaultAsync();
            if (resPreparedLesson != null)
            {
                return resPreparedLesson;
            }
            return null;
        }

        public async Task<bool> UpdatepreparedLessonDAL(PreparedLesson preparedLesson)
        {
            try
            {
                var resPreparedLesson = await _context.PreparedLesson.Where(x => x.LessonId.Equals(preparedLesson.LessonId)).FirstOrDefaultAsync();
                resPreparedLesson.IndexPreparedLesson = preparedLesson.IndexPreparedLesson;
                resPreparedLesson.IfAlowLesson = preparedLesson.IfAlowLesson;
                //resPreparedLesson.CourseId = preparedLesson.CourseId;
                var isOk = await _context.SaveChangesAsync() >= 0;
                if (isOk)
                {
                }
                else
                {
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
