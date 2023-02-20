using DAL.LearningFiles;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.A_DTO;

namespace A_ServerVirtualScool.Controllers
{
    [ApiController]
    public class LearningFileController : Controller
    {
        private ILearningFiles _LearningFilesStor;
        public LearningFileController(ILearningFiles LearningFilesStor)
        {
            _LearningFilesStor = LearningFilesStor;
        }


        //הצגץ קובץ לפי ID שלו
        // GET: api/<LearningFileControllerController>
        [HttpGet]
        [Route("api/getLearningFileAccordingToID/{LearningFileID}")]
        public async Task<ActionResult<Teacher>> getLearningFileAccordingToID(decimal LearningFileID)
        {

            var s = _LearningFilesStor.getLearningFileAccordingToIDDAL(LearningFileID);
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

        //מחזיר רשימה של קבצים לפי המזהה של השיעור
        // GET: api/<LearningFileControllerController>
        [HttpGet]
        [Route("api/getListLearningFilesAccordingToPreparedLessonIDAPI/{PreparedLessonID}")]
        public async Task<ActionResult<Teacher>> getListLearningFilesAccordingToPreparedLessonIDAPI(int PreparedLessonID)
        {

            var s = _LearningFilesStor.getListLearningFilesAccordingToPreparedLessonIDDAL(PreparedLessonID);
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

        //הוספת קובץ
        // POST api/<LearningFileController>
        [HttpPost]
        [Route("/api/addLearningFileAPI")]
        public async Task<ActionResult<bool>> PostLearningFileAPI([FromBody] FileDTO LearningFile)
        {
            var s = await _LearningFilesStor.addLearningFileDAL(LearningFile);
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

        //עידכון קובץ
        // PUT api/<LearningFileController>
        [HttpPut]
        [Route("/api/UpdateLearningFileAPI")]
        public async Task<ActionResult<bool>> UpdateLearningFileAPI([FromBody] LearningFile learningFile)
        {
            var s = await _LearningFilesStor.UpdateLearningFilesDAL(learningFile);
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

        //מחיקת קובץ
        // DELETE api/<LearningFileController>
        [HttpDelete]
        [Route("/api/DeleteFileAPI/{FileId}")]
        public async Task<ActionResult<bool>> DeleteFileAPI(int FileID)
        {
            var s = await _LearningFilesStor.DeleteFileDAL(FileID);
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
