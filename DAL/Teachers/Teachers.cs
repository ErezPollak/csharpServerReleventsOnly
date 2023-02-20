using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Entities.Entities;
using System.Threading.Tasks;
using System.Linq;

namespace DAL.Teachers
{
    public class Teachers : ITeachers
    {
        private My_Virtua_lSchoolContext _context;
        public Teachers(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }



        public async Task<string> getIfTeachersDAL(string userNmase, string passWord)
        {
            string res = "";
            var resS = await _context.Teacher.Where(x => (x.FirstName + " " + x.LastName) == userNmase && x.Passwordd == passWord).FirstOrDefaultAsync();
            if (resS != null)
            {
                if (resS.statusTeacher == false)
                {
                    res = "notValid";
                }
                else
                {
                    if (resS.TeacherId == 1 && (resS.FirstName + " " + resS.LastName) == userNmase && resS.Passwordd == passWord)
                    {
                        res = "isManager";
                    }
                    else if (resS.TeacherId != 1 && (resS.FirstName + " " + resS.LastName) == userNmase && resS.Passwordd == passWord)
                    {
                        res = $"isTeacher#{resS.TeacherId}@";
                    }
                    else if ((resS.FirstName + " " + resS.LastName).Equals(userNmase) && resS.Passwordd != passWord)
                    {
                        res = "erorPassWord";
                    }
                }
            }
            else
            {
                res = "NoExists";
            }
            return res;
        }

        public async Task<bool> addTeacher(Teacher teacher)
        {
            try
            {
                teacher.statusTeacher = true;
                var resTeacher = await _context.Teacher.AddAsync(teacher);

                await _context.SaveChangesAsync();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Teacher> getTeacherAccordingToIDDAL(decimal teacherID)
        {
            try
            {
                var resTeacher = await _context.Teacher.Where(x => x.TeacherId.Equals(teacherID)).FirstOrDefaultAsync();
                return resTeacher;
            }
            catch
            {
                return null;
            }


        }

        public async Task<bool> UpdateALLTeacherDAL(Teacher teacher)
        {
            try
            {
                var resTeacher = await _context.Teacher.Where(x => x.TeacherId.Equals(teacher.TeacherId)).FirstOrDefaultAsync();
                resTeacher.IdentitiyNumber = teacher.IdentitiyNumber;
                resTeacher.FirstName = teacher.FirstName;
                resTeacher.LastName = teacher.LastName;
                resTeacher.Email = teacher.Email;
                resTeacher.Passwordd = teacher.Passwordd;
                resTeacher.statusTeacher = resTeacher.statusTeacher;
                //var resTeacherEnd = _context.Teacher.AddAsync(resTeacher);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<Teacher>> getListTeachersDAL()
        {
            try
            {
                var res = await _context.Teacher.Where(x => x.statusTeacher == true).Select(x => x).ToListAsync();
                return res;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> UpdateStatusTeacherDAL(decimal teacherID)
        {
            try
            {
                var resTeacher = await _context.Teacher.Where(x => x.TeacherId.Equals(teacherID)).FirstOrDefaultAsync();
                if (resTeacher.statusTeacher==true)
                {
                    resTeacher.statusTeacher = false;
                }
                else
                {
                    resTeacher.statusTeacher = true;
                } 
                //var resTeacherEnd = _context.Teacher.AddAsync(resTeacher);
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

