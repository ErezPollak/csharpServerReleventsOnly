using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Teachers
{
    public interface ITeachers
    {
        public Task<string> getIfTeachersDAL(string userNmase, string passWord);
        public Task<bool> addTeacher(Teacher teacher);
        public Task<bool> UpdateALLTeacherDAL(Teacher teacher);
        public Task<bool> UpdateStatusTeacherDAL(decimal teacherID);
        public Task<List<Teacher>> getListTeachersDAL();
        public Task<Teacher> getTeacherAccordingToIDDAL(decimal teacherID);
    }
}
