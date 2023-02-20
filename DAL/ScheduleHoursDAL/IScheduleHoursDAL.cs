using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ScheduleHoursDAL
{
    public interface IScheduleHoursDAL
    {
        public Task<bool> addScheduleHoursDAL(ScheduleHours ScheduleHours);
        public Task<bool> UpdateALLScheduleHoursDAL(ScheduleHours ScheduleHours);
        public Task<bool> DeleteScheduleHoursAPI(decimal id);
        public Task<List<ScheduleHours>> getListScheduleHoursDAL();
        public Task<ScheduleHours> getScheduleHoursAccordingToIdDAL(decimal ScheduleHoursID);
        public Task<decimal> getMaxIndexScheduleHoursDAL();
        
    }
}
