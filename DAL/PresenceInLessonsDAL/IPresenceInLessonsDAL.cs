using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.PresenceInLessonsDAL
{
    public interface IPresenceInLessonsDAL
    {
        public Task<presenceInLessons> getPresenceAccordingToIDDAL(decimal presenceInLessonsID);
        public Task<bool> addPresenceDAL(presenceInLessons presenceInLessons);
        public Task<bool> UpdateAllPresenceHourDAL(presenceInLessons presenceInLessons);
        public Task<bool> UpdatePresenceHourEndDAL(decimal studentID, DateTime endTime);
       // public Task<List<presenceInLessons>> getListPresenceAccordingToTeacherIDDAL();
    }
}
