using DAL.A_DTO;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.CuorsessViewDTO
{
    public class ClassCuorsesViewDTO : IClassCuorsesViewDTO
    {
        private My_Virtua_lSchoolContext _context;
        public ClassCuorsesViewDTO(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }
        
        public async Task<List<CuorsesViewDTO>> getCuorsesViewDTOAccordingToGroupIDDAL(decimal GroupID)
        {
            List<CuorsesViewDTO> CuorsesViewDTO1 = new List<CuorsesViewDTO>();
            List<CoursesToClsss> CuorsesToClass = await _context.CoursesToClsss.Where(x => x.IdGroup== GroupID).Select(x => x).ToListAsync();
            foreach (var item1 in CuorsesToClass)
            {
                List<Course> Cuorses = await _context.Course.Where(x => x.CoueseId == item1.CourseId).Select(x => x).ToListAsync();
                foreach (var item2 in Cuorses)
                {
                    CuorsesViewDTO1.Add(new CuorsesViewDTO(item1.CoursesToClsssId,item1.IdGroup,(decimal)item1.CourseId,item2.CourseName,item2.ImgCourse,item2.TeacherId));
                }
            }
            return CuorsesViewDTO1;
        }

        public async Task<List<CoursesToClsss>> getCuorsesToClasses()
        {
            return await _context.CoursesToClsss.Where(x => true).Select(x => x).ToListAsync();
        }
    }
}
