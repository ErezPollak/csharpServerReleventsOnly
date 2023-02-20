using BLL;
using DAL.A_DTO;
using DAL.SendMailOfPrencipalDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace A_ServerVirtualScool.Controllers
{
    public class SendMailController : Controller
    {
        private SendMailDTOBLL _SendMailDTOBLLStor;
        public SendMailController(SendMailDTOBLL SendMailDTOBLLStor)
        {
            _SendMailDTOBLLStor = SendMailDTOBLLStor;
        }


        // GET: SendMailController/Create
        public ActionResult Create()
        {
            return View();
        }

        //שליחת מייל
        // POST api/<SendMailController>
        [HttpPost]
        [Route("/api/SendMailAPI")]
        public async Task<ActionResult<bool>> SendMailAPI([FromBody] SendMailDTO SendMailDTO)
        {
            var s = _SendMailDTOBLLStor.SendMailDAL(SendMailDTO);
            if (s.Result)
            {
                var obj = new
                {
                    x = s,
                };
                return Ok(obj);
            }
            return BadRequest();
        }

       

        // POST: SendMailController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SendMailController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SendMailController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
