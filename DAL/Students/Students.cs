using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DAL.Group;

namespace DAL.Students
{
    public class Students : IStudents
    {
        private My_Virtua_lSchoolContext _context;

        public Students(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }

        public async Task<string> getStudentsDAL(string fullName, string passWord)
        {

            var res = "eror";
            var resS = await _context.Student.Where(x => (x.FirstName + " " + x.LastName) == fullName)
                .FirstOrDefaultAsync();
            if (resS != null && resS.statusStudent == false)
            {
                res = "notValid";
            }
            else if (resS != null && (resS.FirstName + " " + resS.LastName).Equals(fullName) &&
                     resS.IdentitiyNumber.Equals(passWord))
            {
                res = $"isStudent#{resS.StudentId}@{resS.GroupId}";
            }
            else
            {
                if (resS != null && !resS.IdentitiyNumber.Equals(passWord) &&
                    (resS.FirstName + " " + resS.LastName).Equals(fullName))
                {
                    res = "erorPassWord";
                }
                else
                {
                    res = "NoExists";
                }
            }

            return res;
        }



        public async Task<bool> addStudentDAL(Student student)
        {
            //var resStudent =  _context.Student.AddAsync(student);
            //_context.SaveChangesAsync();
            //if (resStudent != null)
            //    return true;
            //return false;
            try
            {
                var resStudent = await _context.Student.AddAsync(student);
                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Student> getStudentAccordingToIDDAL(string studentID)
        {
            var resStudent = await _context.Student.Where(x => x.IdentitiyNumber == studentID).FirstOrDefaultAsync();
            if (resStudent != null)
            {
                return resStudent;
            }

            return null;
        }

        public async Task<bool> UpdateALLStudentDAL(Student student)
        {

            try
            {
                var resStudent = await _context.Student.Where(x => x.StudentId.Equals(student.StudentId))
                    .FirstOrDefaultAsync();
                resStudent.IdentitiyNumber = student.IdentitiyNumber;
                resStudent.FirstName = student.FirstName;
                resStudent.LastName = student.LastName;
                resStudent.Email = student.Email;
                resStudent.Group = student.Group;
                //var resTeacherEnd = _context.Student.AddAsync(resStudent);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateStatusStudentDAL(string studentID)
        {
            try
            {
                var resStudent = await _context.Student.Where(x => x.StudentId.ToString()==studentID)
                    .FirstOrDefaultAsync();
                if (resStudent.statusStudent == true)
                {
                    resStudent.statusStudent = false;
                }
                else
                {
                    resStudent.statusStudent = true;
                }

                //var resStudentEnd = _context.Student.AddAsync(resStudent);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatrankGroupStudentDAL(string studentID, decimal numberToUp)
        {
            try
            {
                var resStudent = await _context.Student.Where(x => x.IdentitiyNumber.Equals(studentID))
                    .FirstOrDefaultAsync();
                decimal numGroup = (decimal) resStudent.Group.rankGroup;
                numGroup += numberToUp;
                IGroup group1 = new Group.Groupss();
                var group = group1.getGroupAccordingTorankGroupDAL(numGroup);
                resStudent.GroupId = group.Result.GroupsId;
                var resStudentEnd = _context.Student.AddAsync(resStudent);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdatrankGroupToAllStudentDAL()
        {
            try
            {
                List<Student> students = await _context.Student.Select(x => x).ToListAsync();
                foreach (var item in students)
                {
                    this.UpdatrankGroupStudentDAL(item.IdentitiyNumber, 1);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Student>> getStudentAccordingToGroupIDDAL(decimal groupID)
        {
            return await _context.Student.Where(x => x.GroupId == groupID && x.statusStudent == true).Select(x => x).ToListAsync();
        }

        public async Task<List<Student>> getStudentAccordingToGroupAndCourseIDDAL(decimal groupID, decimal coursesID)
        {
            List<CoursesToClsss> lsCoursesToClsss = await _context.CoursesToClsss.Where(x => x.CourseId == coursesID)
                .Select(x => x).ToListAsync();
            List<Groups> slGroups = new List<Groups>();
            foreach (var UPPER in lsCoursesToClsss)
            {
                if (UPPER.IdGroup == groupID)
                {
                    List<Groups> slGroupshelps =
                        await _context.Groups.Where(x => x.GroupsId == groupID).Select(x => x).ToListAsync();
                    foreach (var VARIABLE in slGroupshelps)
                    {
                        slGroups.Add(VARIABLE);
                    }
                }
            }

            List<Student> sStudent = new List<Student>();
            foreach (var UPPER in slGroups)
            {
                List<Student> s1 = getStudentAccordingToGroupIDDAL(UPPER.GroupsId).Result;
                foreach (var VARIABLE in s1)
                {
                    sStudent.Add(VARIABLE);
                }
            }

            return sStudent;
        }
    

}
}
