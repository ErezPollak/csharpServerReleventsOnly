using DAL.A_DTO;
using DAL.CourseToClassDAL;
using DAL.CuorsessViewDTO;
using Entities.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace A_ServerVirtualScool.Controllers
{
    [ApiController]
    public class CourseToClassController : Controller
    {
        private ICourseToClassDAL _CourseToClassDALStor;
        private IClassCuorsesViewDTO _ClassCuorsesViewDTOStor;
        public CourseToClassController(ICourseToClassDAL CourseToClassDALStor, IClassCuorsesViewDTO ClassCuorsesViewDTOStor)
        {
            _ClassCuorsesViewDTOStor = ClassCuorsesViewDTOStor;
            _CourseToClassDALStor = CourseToClassDALStor;
        }
        
        [HttpGet]
        [Route("/api/getListCoursesToClsss")]
        public async Task<ActionResult<List<CoursesToClsss>>> getListCoursesToClsss()
        {
            var s = await _ClassCuorsesViewDTOStor.getCuorsesToClasses();
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

        // החזרת רשימת קורסים לכיתה לפי קוד כיתה
        //GET: api/<CourseToClassController>
        [HttpGet]
        [Route("/api/getListCoursesToClsssAccordingToGroupIDAPI/{result}")]
        public async Task<ActionResult<List<CoursesToClsss>>> getListCoursesToClsssAccordingToGroupIDAPI(decimal result)
        {
            var s = await _ClassCuorsesViewDTOStor.getCuorsesViewDTOAccordingToGroupIDDAL(result);
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

        // החזרת רשימת קורסים לכיתה להצגה לפי קוד כיתה
        //GET: api/<CourseToClassController>
        [HttpGet]
        [Route("api/getListCuorsesViewDTOAccordingToGroupIDDAPI/{groupID}")]
        public async Task<ActionResult<List<CuorsesViewDTO>>> getListCuorsesViewDTOAccordingToGroupIDDAPI(decimal groupID)
        {
            var s = await _CourseToClassDALStor.getListCourseToClassAccordingToGroupIDDAL(groupID);
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
        [Route("api/getListCuorsesViewDTOAccordingToCourseIDDAPI/{courseId}")]
        public async Task<ActionResult<List<CuorsesViewDTO>>> getListCuorsesViewDTOAccordingToCourseIDDAPI(decimal courseId)
        {
            var s = await _CourseToClassDALStor.getListCourseToClassAccordingToCourseIDDAL(courseId);
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

        // החזרת קורס לפי קוד קורס
        //GET: api/<CourseToClassController>
        [HttpGet]
        [Route("api/getCoursesToClsssAccordingToIDDAPI/{CoursesToClsssID}")]
        public async Task<ActionResult<CoursesToClsss>> getCoursesToClsssAccordingToIDDAPI(decimal CoursesToClsssID)
        {
            var s = _CourseToClassDALStor.getCourseToClassAccordingToIDDAL(CoursesToClsssID);
            if (s != null)
            {
                //var obj = new
                //{
                //    x = s,
                //};
                return Ok(s);
            }
            return BadRequest();
        }

        //הוספת קורס לכיתה
        // POST api/<CourseToClassController>
        [HttpPost]
        [Route("api/addCourseToClassAPI/{GroupID}/{CourseID}")]
        public async Task<ActionResult<bool>> addCourseToClassAPI(decimal GroupID, decimal CourseID)
        {
            var s = _CourseToClassDALStor.addCourseToClassDAL(GroupID, CourseID);
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

        //הוספת קורס לכיתה
        // POST api/<CourseToClassController>
        [HttpPost]
        [Route("/api/addCourseToClassAPI")]
        public async Task<ActionResult<bool>> addCourseToClassAPI([FromBody] CoursesToClsss CourseToClass1)
        {
            var s = _CourseToClassDALStor.addCourseToClassDAL(CourseToClass1);
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

        // POST api/<CourseToClassController>
        [HttpPost]
        [Route("/api/addCourseToClass2API/{Course}")]
        public async Task<ActionResult<bool>> addCourseToClass2API(List<string> nameClass,  decimal Course)
        {
            var s =await _CourseToClassDALStor.addCourseToClass2API(nameClass, Course);
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
        

        //מחיקת קורס לכיתה
        // DELETE api/<CourseToClassController>
        [HttpDelete]
        [Route("/api/DeleteCourseToClassAPI/{CourseToClassID}")]
        public async Task<ActionResult<bool>> DeleteCourseToClassAPI(decimal CourseToClassID)
        {
            var s = await _CourseToClassDALStor.DeleteCourseToClassIDDAL(CourseToClassID);
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
