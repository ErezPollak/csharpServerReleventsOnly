using DAL.A_DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;

namespace DAL.CuorsessViewDTO
{
    public interface IClassCuorsesViewDTO
    {
        public Task<List<CuorsesViewDTO>> getCuorsesViewDTOAccordingToGroupIDDAL(decimal GroupID);


        public Task<List<CoursesToClsss>> getCuorsesToClasses();
    }
}
