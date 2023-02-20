using DAL.CourseDAL;
using DAL.Teachers;
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
    public class TeacherController : Controller
    {
        private ITeachers _TeachersStor;
        private ICrousesDAL _CrousesStor;
        public TeacherController(ITeachers TeachersStor, ICrousesDAL CrousesStor)
        {
            _TeachersStor = TeachersStor;
            _CrousesStor = CrousesStor;
        }

        //החזרת רשימת המורוים
        // GET: api/<TeacherController>
        [HttpGet]
        [Route("api/getListTeachersAPI")]
        public async Task<ActionResult<List<Teachers>>> getListTeachersAPI()
        {
            var s =await _TeachersStor.getListTeachersDAL();
            if (s != null)
            {
                return Ok(s);
            }
            return BadRequest();
        }

        //החזרת רשימת קורסים לפי ת.ז. של המורה
        // GET: api/<TeacherController>
        [HttpGet]
        [Route("api/getCourseAccordingToTeachersID/{TeachersID}")]
        public async Task<ActionResult<List<CoursesToClsss>>> getCourseAccordingToTeachersID(decimal TeachersID)
        {
            var s = await _CrousesStor.getCourseAccordingToTeachersIDDAL(TeachersID);
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


        //הצגת מורה לפי ת.ז. שלו
        // GET: api/<TeacherController>
        [HttpGet]
        [Route("api/getTeacherAccordingToID/{TeacherID}")]
        public async Task<ActionResult<Teacher>> getTeacherAccordingToID(decimal TeacherID)
        {
            var s = await _TeachersStor.getTeacherAccordingToIDDAL(TeacherID);
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



        //האם מורה או מנהל
        // GET: api/<TeacherController>
        [HttpGet]
        [Route("/api/getIfTeachers/{userNmase}/{passWord}")]
        public async Task<ActionResult<string>> getIfTeachers(string userNmase, string passWord)
        {
            var s = await _TeachersStor.getIfTeachersDAL(userNmase, passWord);
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

        //הוספת מורה
        // POST api/<TeacherController>
        [HttpPost]
        [Route("/api/PostTeacher")]
        public async Task<ActionResult<bool>> PostTeacher([FromBody] Teacher Teacher)
        {
            var s = await _TeachersStor.addTeacher(Teacher);
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

        //עידכון מורה
        // PUT api/<TeacherController>
        [HttpPut]
        [Route("/api/UpdateALLTeacherAPI")]
        public async Task<ActionResult<bool>> UpdateALLTeacherAPI([FromBody] Teacher Teacher)
        {
            var s = await _TeachersStor.UpdateALLTeacherDAL(Teacher);
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

        //עידכון סטטוס מורה
        // PUT api/<TeacherController>
        [HttpPut]
        [Route("/api/UpdateStatusTeacherAPI/{TeacherID}")]
        public async Task<ActionResult<bool>> UpdateStatusTeacherAPI(decimal TeacherID)
        {
            var s = await _TeachersStor.UpdateStatusTeacherDAL(TeacherID);
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

