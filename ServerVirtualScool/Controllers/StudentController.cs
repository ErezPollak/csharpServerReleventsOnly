
using DAL.CourseDAL;
using DAL.Students;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace A_ServerVirtualScool.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IStudents _studentStor;
        private ICrousesDAL _CrousesStor;
        public StudentController(IStudents studentStor, ICrousesDAL CrousesStor)
        {
            _studentStor = studentStor;
            _CrousesStor = CrousesStor;
        }

        //האם סטודנט
        // GET: api/<StudentController>
        [HttpGet]
        [Route("/api/getIfStudents/{fullName}/{passWord}")]
        public async Task<ActionResult<string>> getIfStudents(string fullName, string passWord)
        {
            var s = await _studentStor.getStudentsDAL(fullName, passWord);
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

        //החזרת קורסים לפי ת.ז. של התלמיד
        // GET: api/<StudentController>
        [HttpGet]
        [Route("api/getCoursesAccordingToStudent/{StudentID}")]
        public async Task<ActionResult<List<Course>>> getCoursesAccordingToStudent(decimal StudentID)
        {
            var s = await _CrousesStor.getCourseAccordingToStudentIDDAL(StudentID);
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

        //הצגת סטודנט לפי ת.ז. שלו
        // GET: api/<StudentController>
        [HttpGet]
        [Route("api/getStudentAccordingToID/{StudentID}")]
        public async Task<ActionResult<Student>> getStudentAccordingToID(string StudentID)
        {
            var s = _studentStor.getStudentAccordingToIDDAL(StudentID);
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

        //הצגת סטודנט לפי קוד הכיתה שלו
        // GET: api/<StudentController>
        [HttpGet]
        [Route("api/getStudentAccordingToGroupIDAPI/{GroupID}")]
        public async Task<ActionResult<List<Student>>> getStudentAccordingToGroupIDAPI(decimal GroupID)
        {
            var s = await _studentStor.getStudentAccordingToGroupIDDAL(GroupID);
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
        
      // החזרת רשימת סטודנטים בשייכים לקורס מסויים..
        // GET: api/<StudentController>
        [HttpGet]
        [Route("api/getStudentAccordingToGroupAndCourseIDDAL/{GroupID}/{coursesID}")]
        public async Task<ActionResult<List<Student>>> getStudentAccordingToGroupAndCourseIDDAL(decimal GroupID,decimal coursesID)
        {
            var s = _studentStor.getStudentAccordingToGroupAndCourseIDDAL(GroupID,coursesID);
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

        //הוספת סטודנט
        // POST api/<StudentController>
        [HttpPost]
        [Route("/api/PostStudents")]
        public async Task<ActionResult<bool>> PostStudents([FromBody] Student student)
        {
            var s = await _studentStor.addStudentDAL(student);
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

        //עידכון תלמיד
        // PUT api/<StudentController>
        [HttpPut]
        [Route("/api/UpdateALLStudentAPI")]
        public async Task<ActionResult<bool>> UpdateALLStudentAPI([FromBody] Student Student)
        {
            var s = await _studentStor.UpdateALLStudentDAL(Student);
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

        //עידכון סטטוס תלמיד
        // PUT api/<StudentController>
        [HttpPut]
        [Route("/api/UpdateStatusStudentAPI/{StudentID}")]
        public async Task<ActionResult<bool>> UpdateStatusStudentAPI(string StudentID)
        {
            var s = await _studentStor.UpdateStatusStudentDAL(StudentID);
            if (s != null && s == true)
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }

        //עידכון כיתה של תלמיד ע"י העלתו לכיתה גבוהה יותר
        // PUT api/<StudentController>
        [HttpPut]
        [Route("/api/UpdaterankGroupStudentAPI/{studentID}/{numberToUp}")]
        public async Task<ActionResult<bool>> UpdaterankGroupStudentAPI(string studentID, decimal numberToUp)
        {
            var s = await _studentStor.UpdatrankGroupStudentDAL(studentID, numberToUp);
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

        //עידכון כל בית הספר העלת כיתה של כל התלמידים
        // PUT api/<StudentController>
        [HttpPut]
        [Route("/api/UpdatrankGroupToAllStudentAPI")]
        public async Task<ActionResult<bool>> UpdatrankGroupToAllStudentAPI()
        {
            var s = await _studentStor.UpdatrankGroupToAllStudentDAL();
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
