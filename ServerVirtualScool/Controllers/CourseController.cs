using DAL.A_DTO;
using DAL.CourseDAL;
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
    public class CourseController : Controller
    {

        private ICrousesDAL _CrousesStor;
        public CourseController(ICrousesDAL CrousesStor)
        {
            _CrousesStor = CrousesStor;
        }

        //החזרת רשימת כל הקורסים
        // GET: api/<CourseController>
        [HttpGet]
        [Route("api/getALLCoursesAPI")]
        public async Task<ActionResult<List<Groups>>> getALLCoursesAPI()
        {
            var s = await _CrousesStor.getAllCourseDAL();
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

        //החזרת רשימת כיתות לפי קורס הרשאה של מורה או מנהל
        // GET: api/<CourseController>
        [HttpGet]
        [Route("api/getGroupeAccordingToCoursesIDAPI/{CourseID}")]
        public async Task<ActionResult<List<Groups>>> getGroupeAccordingToCoursesIDAPI(decimal CourseID)
        {
            var s = await   _CrousesStor.getGroupeAccordingToCoursesIDDAL(CourseID);
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

        //הוספת קורס 
        // POST api/<CourseController>
        [HttpPost]
        [Route("/api/addCourseAPI")]
        public async Task<ActionResult<bool>> addCourseAPI([FromBody] coursDTO coursDTO)
        {
            
            var s = await _CrousesStor.addCourseDAL(coursDTO);
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


        //עידכון קורס
        // PUT api/<CourseController>
        [HttpPut]
        [Route("/api/UpdateALLCourseAPI")]
        public async Task<ActionResult<bool>> UpdateALLCourseAPI([FromBody] coursDTO course)
        {
            var s = await _CrousesStor.UpdateALLCourseDAL(course);
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

        //מחיקת קורס 
        // DELETE api/<CourseController>
        [HttpDelete]
        [Route("/api/DeleteCoursesAPI/{CourseID}")]
        public async Task<ActionResult<bool>> DeleteCoursesAPI(decimal CourseID)
        {
            var s = await _CrousesStor.DeleteCourseDAL(CourseID);
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

