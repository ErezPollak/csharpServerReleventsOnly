using AutoMapper;
using DAL.A_DTO;
using DAL.CourseToClassDAL;
using DAL.PreparedLessons;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL.CourseDAL
{
    public class CoursesDAL : ICrousesDAL
    {
        private My_Virtua_lSchoolContext _context;
        private readonly IMapper _mapper;
        public CoursesDAL(My_Virtua_lSchoolContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public CoursesDAL()
        {

        }
        public async Task<List<Course>> getCourseAccordingToTeachersIDDAL(decimal TeacherID)
        {

            var res = await _context.Course.Where(x => x.TeacherId == TeacherID).Select(x => x).ToListAsync();
            return res;
        }

        // החזרת רשימת קורסים לפי ת.ז.של תלמיד
        public async Task<List<Course>> getCourseAccordingToStudentIDDAL(decimal StudentID)
        {
            List<CoursesToClsss> resListCoursesToClsss = new List<CoursesToClsss>();
            List<Course> resListCourses = new List<Course>();
         
            var resStudent = await _context.Student.Where(x => (x.StudentId == StudentID)).FirstOrDefaultAsync();
            if (resStudent != null)
            {
                resListCoursesToClsss = await _context.CoursesToClsss.Where(x => x.IdGroup == resStudent.GroupId).Select(x => x).ToListAsync();
                if (resListCoursesToClsss != null)
                {
                    foreach (var item in resListCoursesToClsss)
                    {
                        var course = await _context.Course.Where(x => x.CoueseId == item.CourseId).Select(x => x).FirstOrDefaultAsync();
                        course.CoursesToClsss = null;
                        resListCourses.Add(course); 
                    }
                }
            }
            return resListCourses;
        }
        // החזרת רשימת כיתות לפי קוד קורס בשביל הצגתם למורה או למנהל
        public async Task<List<Groups>> getGroupeAccordingToCoursesIDDAL(decimal CoursesID)
        {
            List<CoursesToClsss> resListCoursesToClsss = new List<CoursesToClsss>();
            List<Groups> resListGroups = new List<Groups>();
            resListGroups = null;
            Groups Group;
            foreach (var item1 in _context.CoursesToClsss)
            {
                if (item1.CourseId == CoursesID)
                {
                    Group = await _context.Groups.Where(x => x.GroupsId == item1.IdGroup).FirstOrDefaultAsync();
                    resListGroups.Add(Group);
                }
            }
            return resListGroups;
        }
        //הוספת קורס
        public async Task<bool> addCourseDAL(coursDTO course)
        {
            int mone = 0;
            List<Course> Course = new List<Course>();
            foreach (var item in _context.Course)
            {
                //if (item.CourseName.IndexOf(course.CourseName) != -1)
                //{
                //    mone++;
                //}
                if (course.CourseName == item.CourseName)
                {
                    return false;
                }
            }
            //if (mone > 0)
            //{
            //    course.CourseName = course.CourseName + "-" + mone;
            //}
            var CourseModel = _mapper.Map<Course>(course);
            CourseModel.ImgCourse = course.Document[0].file;
            // Course c = new Course() { CoueseId = course.CoueseId, CourseName = course.CourseName, ImgCourse = course.Document[0].file, TeacherId = course.TeacherId };
            var resCourse = await _context.Course.AddAsync(CourseModel);
            try
            {

           var x=await _context.SaveChangesAsync()>=0;
                if(x==true)
                {

                }
            }catch(Exception ex)
            {

            }
            return true;
        }

        //עידכון קורס
        public async Task<bool> UpdateALLCourseDAL(coursDTO course)
        {
            try
            {
                var resCourse = await _context.Course.Where(x => x.CoueseId.Equals(course.CoueseId)).FirstOrDefaultAsync();
                resCourse.CourseName = course.CourseName;
                resCourse.TeacherId = course.TeacherId;
                
                var CourseModel = _mapper.Map<Course>(course);
                CourseModel.ImgCourse = course.Document[0].file;
                
                resCourse.ImgCourse = CourseModel.ImgCourse;
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
        public async Task<bool> DeleteCourseDAL(decimal CourseID)
        {
            try
            {
                ICourseToClassDAL coursesToClsss = new CourseToClassesDAL();
                var rescoursesToClsss = await _context.CoursesToClsss.Where(x => x.CourseId == CourseID).Select(x => x).ToListAsync();
                foreach (var item in rescoursesToClsss)
                {
                    coursesToClsss.DeleteCourseToClassIDDAL(item.CoursesToClsssId);
                }
                var resCourse = await _context.Course.Where(x => x.CoueseId.Equals(CourseID)).FirstOrDefaultAsync();
                var resCourseEnd = _context.Course.Remove(resCourse);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Course>> getAllCourseDAL()
        {
            return await _context.Course.Select(x => x).ToListAsync();
        }

        public async Task<decimal> addCourseTestDAL(decimal CoursesID, decimal TeacherID)
        {
            //var resCourse = await _context.Course.Where(x => x.CoueseId.Equals(CoursesID)).FirstOrDefaultAsync();
            //if (resCourse != null)
            //{
            //    Course course1 = new Course() { CourseName = "The test in " + resCourse.CourseName, ImgCourse = resCourse.ImgCourse, TeacherId = TeacherID };
            //    this.addCourseDAL(course1);
            //    //האם באמת זה הקוד שלל הקורס החדש???
            //    return course1.CoueseId;
            //}
           return -1;
        }
    }
}
