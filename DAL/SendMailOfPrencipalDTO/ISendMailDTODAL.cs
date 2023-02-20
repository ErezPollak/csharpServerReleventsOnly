using DAL.A_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SendMailOfPrencipalDTO
{
    public interface ISendMailDTODAL
    {

        public Task<bool> SendMailDAL(SendMailDTO SendMailDTO);
    }
}
