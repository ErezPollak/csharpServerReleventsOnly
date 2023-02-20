using DAL.ScheduleHoursDAL;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_ServerVirtualScool.Controllers
{
    [ApiController]
    public class ScheduleHoursController : Controller
    {
        private IScheduleHoursDAL _ScheduleHourssDALStor;
        public ScheduleHoursController(IScheduleHoursDAL ScheduleHoursDALStor)
        {
            _ScheduleHourssDALStor = ScheduleHoursDALStor;
        }

        // החזרת כל שעות מערכת 
        //GET: api/<ScheduleHoursController>
        [HttpGet]
        [Route("api/getListScheduleHoursAPI")]
        public async Task<ActionResult<List<ScheduleHours>>> getListScheduleHoursAPI()
        {
            var s = await _ScheduleHourssDALStor.getListScheduleHoursDAL();
            if (s != null)
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }

        // החזרת שעת המערכת בעלת הקוד מזהה הגדול ביותר 
        //GET: api/<ScheduleHoursController>
        [HttpGet]
        [Route("api/getMaxScheduleHoursIndexAPI")]
        public async Task<ActionResult<decimal>> getMaxScheduleHoursIndexAPI()
        {
            var s = _ScheduleHourssDALStor.getMaxIndexScheduleHoursDAL();
            if (s != null)
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }

        // הוספת שעה לזמנים של המערכת
        // POST api/<ScheduleHoursController>
        [HttpPost]
        [Route("api/addScheduleHoursAPI")]
        public async Task<ActionResult<bool>> addScheduleHoursAPI([FromBody] ScheduleHours scheduleHours)
        {
            var s = await _ScheduleHourssDALStor.addScheduleHoursDAL(scheduleHours);
            if (s.Equals(true))
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }
        //עידכון זמן של השעות במערכת
        //  PUT api/<ScheduleHoursController>
        [HttpPut]
        [Route("/api/UpdateScheduleHoursAPI")]
        public async Task<ActionResult<bool>> UpdateScheduleHoursAPI([FromBody] ScheduleHours ScheduleHours)
        {
            var s = await _ScheduleHourssDALStor.UpdateALLScheduleHoursDAL(ScheduleHours);
            if (s != null)
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }

        [HttpDelete] [Route("/api/DeleteScheduleHoursAPI/{id}")]
        public async Task<ActionResult<bool>> DeleteScheduleHoursAPI(decimal id)
        {
            var s = await _ScheduleHourssDALStor.DeleteScheduleHoursAPI(id);
            if (s != null && s)
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }
        
    }
}
