using DAL.PreparedLessons;
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
    public class PreparedLessonController : Controller
    {
        private IPreparedLessons _PreparedLessonStor;
        public PreparedLessonController(IPreparedLessons PreparedLessonStor)
        {
            _PreparedLessonStor = PreparedLessonStor;
        }

        //הצגת שיעור לפי המזהה שלו
        // GET: api/<PreparedLessonControllerController>
        [HttpGet]
        [Route("api/getPreparedLessonAccordingToIDAPI/{PreparedLessonID}")]
        public async Task<ActionResult<PreparedLesson>> getPreparedLessonAccordingToIDAPI(decimal PreparedLessonID)
        {

            var s = await _PreparedLessonStor.getPreparedLessonAccordingToIDDAL(PreparedLessonID);
            if (s != null)
            {
                return Ok(s);
            }
            return BadRequest();
        }

        // מחזיר רשימה של שיעורים לפי המזהה של הקורס שלהם וגם לפי כיתה שהתקבלה
        // GET: api/<PreparedLessonControllerController>
        [HttpGet]
        [Route("api/getListPreparedLessonsAccordingToCourseIDToGroupAPI/{CourseID}/{Group}")]
        public async Task<ActionResult<List<PreparedLesson>>> getListPreparedLessonsAccordingToCourseIDToGroupAPI(decimal CourseID, decimal Group)
        {

            var s =await _PreparedLessonStor.getListPreparedLessonsAccordingToCourseIDToGroupDAL(CourseID, Group );
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

        // מחזיר רשימה של שיעורים לפי המזהה של הקורס שלהם וגם לפי הרשאת הגישה של התלמיד
        // GET: api/<PreparedLessonControllerController>
        [HttpGet]
        [Route("api/getListPreparedLessonsAccordingToPreparedLessonIDToStusentAPI/{CourseID}/{StudentID}")]
        public async Task<ActionResult<List<PreparedLesson>>> getListPreparedLessonsAccordingToPreparedLessonIDToStusentAPI(decimal CourseID, string StudentID)
        {

            var s = await _PreparedLessonStor.getListPreparedLessonsAccordingToCourseIDToStusentDAL(CourseID, StudentID);
            if (s != null)
            {
                return Ok(s);
            }
            return BadRequest();
        }

        // מחזיר רשימה של שיעורים לפי המזהה של הקורס שלהם וגם לפי הרשאת הגישה של מורה או מנהל
        // GET: api/<PreparedLessonControllerController>
        [HttpGet]
        [Route("api/getListPreparedLessonsAccordingToPreparedLessonIDToTeacherAPI/{CourseID}/{StudentID}")]
        public async Task<ActionResult<List<PreparedLesson>>> getListPreparedLessonsAccordingToPreparedLessonIDToTeacherAPI(decimal CourseID, string StudentID)
        {

            var s = await _PreparedLessonStor.getListPreparedLessonsAccordingToCourseIDToStusentDAL(CourseID, StudentID);
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

        //הוספת שיעור
        // POST api/<PreparedLessonController>
        [HttpPost]
        [Route("api/PostPreparedLessonAPI")]
        public async Task<ActionResult<bool>> PostPreparedLessonAPI([FromBody] PreparedLesson preparedLesson)
        {
            var s = await _PreparedLessonStor.addPreparedLessonDAL(preparedLesson);
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

        //עידכון שיעור
        // PUT api/<PreparedLessonController>
        [HttpPut]
        [Route("/api/UpdatePreparedLessonAPI")]
        public async Task<ActionResult<bool>> UpdatePreparedLessonAPI([FromBody] PreparedLesson preparedLesson)
        {
            var s = await _PreparedLessonStor.UpdatepreparedLessonDAL(preparedLesson);
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

        //מחיקת שיעור
        // DELETE api/<PreparedLessonController>
        [HttpDelete]
        [Route("/api/DeletePreparedLessonAPI/{PreparedLessonID}")]
        public async Task<ActionResult<bool>> DeletePreparedLessonAPI(decimal PreparedLessonID)
        {
            var s = await _PreparedLessonStor.DeletePreparedLessonDAL(PreparedLessonID);
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
