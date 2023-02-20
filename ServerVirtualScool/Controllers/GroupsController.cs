using DAL.A_DTO;
using DAL.Group;
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
    public class GroupsController : Controller
    {
        private IGroup _GroupStor;
        public GroupsController(IGroup GroupStor)
        {
            _GroupStor = GroupStor;
        }


       // החזרת רשימת כיתות
         //GET: api/<GroupsController>
        [HttpGet]
        [Route("/api/getListGroupeAPI")]
        public async Task<ActionResult<List<Groups>>> getListGroupeAPI()
        {
            var s = _GroupStor.getListGroupsDAL();
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

        // החזרת כיתה לפי ת.ז. של קבוצה
        //GET: api/<GroupsController>
        [HttpGet]
        [Route("api/getGroupAccordingToIDAPI/{GroupID}")]
        public async Task<ActionResult<Groups>> getGroupAccordingToIDAPI(decimal GroupID)
        {
            var s = _GroupStor.getGroupAccordingToIDDAL(GroupID);
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

        // החזרת הקוד של הכיתה הכי גבוהה
        //GET: api/<GroupsController>
        [HttpGet]
        [Route("api/getMaxRankGroupAPI")]
        public async Task<ActionResult<decimal?>> getMaxRankGroupAPI()
        {
            var s = _GroupStor.getMaxrankGroupDAL(); ;
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

        // הוספת כיתה
        // POST api/<GroupsController>
        [HttpPost]
        [Route("/api/addGroupsAPI")]
        public async Task<ActionResult<bool>> addGroupsAPI(Groups Groups)
        {
            
            var s = await _GroupStor.addGroupDAL(Groups);
            if (s)
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }

        //עידכון כיתה
       //  PUT api/<GroupsController>
        [HttpPut]
        [Route("/api/UpdateALLGroupsAPI")]
        public async Task<ActionResult<bool>> UpdateALLGroupsAPI(GroupDto Groups)
        {
            var s = await _GroupStor.UpdateALLGroupDAL(Groups);
            if (s)
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }

        //מחיקת כיתות
        // DELETE api/<GroupsController>
        [HttpDelete]
        [Route("/api/DeleteLGroupsAPI")]
        public async Task<ActionResult<bool>> DeleteLGroupsAPI([FromBody] decimal GroupsID)
        {
            var s = await _GroupStor.deleteGroupDAL(GroupsID);
            if (s)
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
