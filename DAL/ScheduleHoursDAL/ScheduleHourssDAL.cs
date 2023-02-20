using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ScheduleHoursDAL
{
    public class ScheduleHourssDAL : IScheduleHoursDAL
    {

        private My_Virtua_lSchoolContext _context;
        public ScheduleHourssDAL(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }

        public async Task<bool> addScheduleHoursDAL(ScheduleHours ScheduleHours)
        {
            try
            {
                decimal maxId = 0;

                if (_context.ScheduleHours.Count() != 0)
                {
                    maxId = _context.ScheduleHours.Max(hour => hour.ScheduleHoursIndex) + 1;
                }

                var span = new TimeSpan(2, 0, 0);

                var addedHour = new ScheduleHours();
                addedHour.ScheduleHoursIndex = maxId;
                addedHour.TimeBeginning = ScheduleHours.TimeBeginning.Value.Add(span);
                addedHour.TimeEnd = ScheduleHours.TimeEnd.Value.Add(span);

                await _context.ScheduleHours.AddAsync(addedHour);
                
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteScheduleHoursAPI(decimal id)
        {
            try
            {
                var sch = await _context.ScheduleHours.Where(sch => sch.ScheduleHoursIndex == id).FirstOrDefaultAsync();
                _context.ScheduleHours.Remove(sch);
                var isOk = await _context.SaveChangesAsync() >= 0;
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<ScheduleHours>> getListScheduleHoursDAL()
        {
            return await _context.ScheduleHours.Select(x => x).ToListAsync();
        }

        public async Task<decimal> getMaxIndexScheduleHoursDAL()
        {
            //איך עושים בפונקצית לינק מקסימום???
            decimal maxIndex = 0;
           List< ScheduleHours> ScheduleHours = await _context.ScheduleHours.Select(x => x).ToListAsync();
            foreach (var item in ScheduleHours)
            {
                if (item.ScheduleHoursIndex> maxIndex)
                {
                    maxIndex = item.ScheduleHoursIndex;
                }
            }
            return maxIndex;
        }

        public async Task<ScheduleHours> getScheduleHoursAccordingToIdDAL(decimal ScheduleHoursID)
        {
            return await _context.ScheduleHours.Where(x => x.ScheduleHoursIndex == ScheduleHoursID).Select(x=>x).FirstOrDefaultAsync();
        }

        public async Task<bool> UpdateALLScheduleHoursDAL(ScheduleHours ScheduleHours)
        {
            try
            {
                var resScheduleHours = await _context.ScheduleHours.Where(x => x.ScheduleHoursIndex.Equals(ScheduleHours.ScheduleHoursIndex)).FirstOrDefaultAsync();
                resScheduleHours.TimeBeginning = ScheduleHours.TimeBeginning;
                resScheduleHours.TimeEnd = ScheduleHours.TimeEnd;
                var resScheduleHoursEnd = _context.ScheduleHours.AddAsync(resScheduleHours);
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
