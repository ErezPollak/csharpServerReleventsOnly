using DAL.A_DTO;
using DAL.ScheduleDAL;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_ServerVirtualScool.Controllers
{
    [ApiController]
    public class ScheduleController : Controller
    {
        private IScheduleDAL _ScheduleDALStor;
        public ScheduleController(IScheduleDAL ScheduleDALStor)
        {
            _ScheduleDALStor = ScheduleDALStor;
        }

        // החזרת שעות מערכת לפי קוד תלמיד
        //GET: api/<ScheduleController>
        [HttpGet]
        [Route("api/getListScheduleAccordingToStudentIDAPI/{StudentID}")]
        public async Task<ActionResult<List<Schedule>>> getListScheduleAccordingToStudentIDAPI(string StudentID)
        {
            var s = _ScheduleDALStor.getScheduleCourseAccordingToStudentIDDAL(StudentID);
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

        [HttpGet]
        [Route("api/getListScheduleAPI")]
        public async Task<ActionResult<List<Schedule>>> getListScheduleAPI()
        {
            var s = await _ScheduleDALStor.getScheduleCourse();
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

        // החזרת שעות מערכת לפי קוד מורה
        //GET: api/<ScheduleController>
        [HttpGet]
        [Route("api/getListScheduleAccordingToTeacherIDAPI/{TeacherID}")]
        public async Task<ActionResult<List<Schedule>>> getListScheduleAccordingToTeacherIDAPI(decimal TeacherID)
        {
            var s = await _ScheduleDALStor.getScheduleCourseAccordingToTeacherIDDAL(TeacherID);
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

        // החזרת שעות מערכת לפי קוד כיתה
        //GET: api/<ScheduleController>
        [HttpGet]
        [Route("api/getListScheduleAccordingToGroupIDAPI/{GroupID}")]
        public async Task<ActionResult<List<Schedule>>> getListScheduleAccordingToGroupIDAPI(decimal GroupID)
        {
            var s = await _ScheduleDALStor.getScheduleCourseAccordingToGoupIDDAL(GroupID);
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

       

      

        //הוספת קורס למערכת שעות
        // POST api/<ScheduleController>
        [HttpPost]
        [Route("api/addScheduleCorses")]
        public async Task<ActionResult<bool>> addScheduleCorses([FromBody] Schedule courseTestDTO)
        {
            var s = await _ScheduleDALStor.addScheduleCourseDAL(courseTestDTO);
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

        //מחיקת קורס למערכת שעות
        // DELETE api/<ScheduleController>
        [HttpDelete]
        [Route("/api/DeleteScheduleCorsesAPI/{ScheduleID}")]
        public async Task<ActionResult<bool>> DeleteScheduleCorsesAPI(decimal ScheduleID)
        {
            var s = await _ScheduleDALStor.DeleteScheduleCourseDAL(ScheduleID);
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

        //עידכון קורס למערכת שעות
        // PUT api/<ScheduleController>
        [HttpPut]
        [Route("/api/UpdateScheduleAPI")]
        public async Task<ActionResult<bool>> UpdateScheduleAPI([FromBody] Schedule Schedule)
        {
            var s = await _ScheduleDALStor.UpdateScheduleCourseDAL(Schedule);
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
    }
}
