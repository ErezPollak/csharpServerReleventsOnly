using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DAL.A_DTO
{
   
    public class SendMailDTO
    {
        public string fullname { get; set; }
        public string mail { get; set; }
        public string phone { get; set; }
        public string Message { get; set; }

        //public SendMailDTO(string fullname, string mail, string phone, string message)
        //{
        //    this.fullname = fullname;
        //    this.mail = mail;
        //    this.phone = phone;
        //    Message = message;
        //}

        //public SendMailDTO()
        //{
        //}
    }
}
