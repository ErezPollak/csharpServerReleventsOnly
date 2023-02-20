using DAL.A_DTO;
using DAL.CourseTestsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_ServerVirtualScool.Controllers
{
    [ApiController]
    public class CourseTestController : Controller
    {

        private ICourseTestDTO _CourseTestStor;
        public CourseTestController(ICourseTestDTO CourseTestStor)
        {
            _CourseTestStor = CourseTestStor;
        }

        // החזרת רשימת מבחנים לפי ת.ז. של תלמיד
        //GET: api/<CourseTestController>
        [HttpGet]
        [Route("api/getListScheduleTestCoursAccordingToStudentIDAPI/{StudentID}")]
        public async Task<ActionResult<List<CourseTestDTO>>> getListScheduleTestCoursAccordingToStudentIDAPI(string StudentID)
        {
            var s = _CourseTestStor.getCourseTestAccordingTostudentIDDAL(StudentID);
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

        // החזרת רשימת מבחנים לפי קוד מזהה של מורה
        //GET: api/<CourseTestController>
        [HttpGet]
        [Route("api/getListScheduleTestCoursAccordingToTeacherIDAPI/{StudentID}")]
        public async Task<ActionResult<List<CourseTestDTO>>> getListScheduleTestCoursAccordingToTeacherIDAPI(decimal TeacherID)
        {
            var s = _CourseTestStor.getCourseTestAccordingToteacherIDDAL(TeacherID);
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

        //הוספת מבחן למערכת שעות
        // POST api/<CourseTestController>
        [HttpPost]
        [Route("api/addCourseTestCorsesTest")]
        public async Task<ActionResult<bool>> addCourseTestCorsesTest([FromBody] CourseTestDTO courseTestDTO)
        {
            var s = _CourseTestStor.addCourseTestDAL(courseTestDTO);
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
    }
}
