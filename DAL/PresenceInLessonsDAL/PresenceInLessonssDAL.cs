using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PresenceInLessonsDAL
{
    public class PresenceInLessonssDAL : IPresenceInLessonsDAL
    {
        private My_Virtua_lSchoolContext _context;
        public PresenceInLessonssDAL(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }

        public async Task<presenceInLessons> getPresenceAccordingToIDDAL(decimal presenceInLessonsID)
        {
            return await _context.presenceInLessons.Where(x => (x.presenceInLessonsId == presenceInLessonsID)).FirstOrDefaultAsync();

        } 

        public async Task<bool> addPresenceDAL(presenceInLessons presenceInLessons)
        {
            var resPresenceInLessonss = await _context.presenceInLessons.AddAsync(presenceInLessons);
            _context.SaveChangesAsync();
            if (resPresenceInLessonss != null)
                return true;
            return false;
        }

        public async Task<bool> UpdatePresenceHourEndDAL(decimal studentID, DateTime endTime)
        {
            try
            {
                Task<decimal> indexPresence = this.getMaxHourStartInPresenceInLessonssAccordingToStudentID(studentID);
                var resPresence = await _context.presenceInLessons.Where(x => (x.presenceInLessonsId == indexPresence.Result)).FirstOrDefaultAsync();
                resPresence.TimeEnd = endTime;
                var resPresenceEnd = _context.presenceInLessons.AddAsync(resPresence);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<decimal> getMaxHourStartInPresenceInLessonssAccordingToStudentID(decimal studentID)
        {
            decimal maxIndexpresenceInLessons = 0;
            //אי אפשר שזה יהיה נל??
            DateTime maxTimeBeginning = new DateTime();
            List<presenceInLessons> lstpresenceInLessons = await _context.presenceInLessons.Where(x => x.StudentId == studentID).Select(x => x).ToListAsync();
            foreach (var item in lstpresenceInLessons)
            {
                if (maxTimeBeginning == null)
                {
                    maxTimeBeginning = (DateTime)item.TimeBeginning;
                    maxIndexpresenceInLessons = item.presenceInLessonsId;
                }
                else if ((DateTime)item.TimeBeginning > maxTimeBeginning)
                {
                    maxTimeBeginning = (DateTime)item.TimeBeginning;
                    maxIndexpresenceInLessons = item.presenceInLessonsId;
                }
            }
            return maxIndexpresenceInLessons;
        }

        public async Task<bool> UpdateAllPresenceHourDAL(presenceInLessons presenceInLessons)
        {
            try
            {
                var resPresence = await _context.presenceInLessons.Where(x => (x.presenceInLessonsId == presenceInLessons.presenceInLessonsId)).FirstOrDefaultAsync();
                resPresence.TimeEnd = presenceInLessons.TimeEnd;
                resPresence.DateToday = presenceInLessons.DateToday;
                resPresence.StudentId = presenceInLessons.StudentId;
                resPresence.CoursesToClsssId = presenceInLessons.CoursesToClsssId;
                resPresence.TimeBeginning = presenceInLessons.TimeBeginning;
                var resPresenceEnd = _context.presenceInLessons.AddAsync(resPresence);
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
