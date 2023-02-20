
using Entities.Entities;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Students
{
    public interface IStudents
    {
        public Task<string> getStudentsDAL(string fullName, string passWord);
        public Task<bool> UpdateALLStudentDAL(Student student);
        public Task<bool> UpdateStatusStudentDAL(string studentID);
        public Task<bool> UpdatrankGroupStudentDAL(string studentID,decimal numberToUp);
        public Task<bool> UpdatrankGroupToAllStudentDAL();
        public Task<bool> addStudentDAL(Student student);
        public Task<Student> getStudentAccordingToIDDAL(string student);
        public Task<List<Student>> getStudentAccordingToGroupIDDAL(decimal groupID);
        public Task<List<Student>> getStudentAccordingToGroupAndCourseIDDAL(decimal groupID,decimal coursesID);
    }
}
