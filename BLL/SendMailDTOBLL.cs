using DAL.A_DTO;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SendMailDTOBLL
    {
        public async Task<bool> SendMailDAL(SendMailDTO SendMailDTO)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("myprojectvirtualschool@gmail.com");
                    mail.To.Add(SendMailDTO.mail);
                    mail.Subject = "Hello" + SendMailDTO.fullname;
                    mail.Body = "<h1> Hello</h1> \n" + SendMailDTO.Message;
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("myprojectvirtualschool@gmail.com", "rhzhpmxtfhyewzqt");
                        smtp.EnableSsl = true;
                         smtp.Send(mail);
                    }
                }

            }
            catch (Exception ex)
            {

            }
            return true;
            //???
            bool d = true;
            return d;
        }
    }
}
