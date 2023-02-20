using DAL.PresenceInLessonsDAL;
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
    public class presenceInLessonsController : Controller
    {
        private IPresenceInLessonsDAL _PresenceInLessonsStor;
        public presenceInLessonsController(IPresenceInLessonsDAL PresenceInLessonsStor)
        {
            _PresenceInLessonsStor = PresenceInLessonsStor;
        }

        //החזרת נוכחות לפי מזהה
        // GET: api/<presenceInLessonsController>
        [HttpGet]
        [Route("api/getpresenceInLessonsAccordingToIDAPI")]
        public async Task<ActionResult<presenceInLessons>> getpresenceInLessonsAccordingToIDAPI(decimal presenceInLessonsID)
        {
            var s = _PresenceInLessonsStor.getPresenceAccordingToIDDAL(presenceInLessonsID);
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

        //הוספת נוכחות לתלמיד
        // POST api/<presenceInLessonsController>
        [HttpPost]
        [Route("api/addpresenceInLessonsOfStudentAPI")]
        public async Task<ActionResult<bool>> addpresenceInLessonsOfStudentAPI([FromBody] presenceInLessons presenceInLessons)
        {
            var s = _PresenceInLessonsStor.addPresenceDAL(presenceInLessons);
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
        //עידכון נוכחות כניסה
        // PUT api/<presenceInLessonsController>
        [HttpPut]
        [Route("/api/UpdatePresenceInLessonsStartingAPI")]
        public async Task<ActionResult<bool>> UpdatePresenceInLessonsStartingAPI([FromBody] presenceInLessons presenceInLessons)
        {
            var s = await _PresenceInLessonsStor.UpdateAllPresenceHourDAL(presenceInLessons);
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

        //עידכון נוכחות שלם
        // PUT api/<presenceInLessonsController>
        [HttpPut]
        [Route("/api/UpdateALLPresenceInLessonsAPI")]
        public async Task<ActionResult<bool>> UpdateALLPresenceInLessonsAPI(decimal StudentID ,DateTime time)
        {
            var s = await _PresenceInLessonsStor.UpdatePresenceHourEndDAL(StudentID, time);
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
