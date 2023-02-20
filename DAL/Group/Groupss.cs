using DAL.A_DTO;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Group
{
    public class Groupss : IGroup
    {
        private My_Virtua_lSchoolContext _context;
        public Groupss(My_Virtua_lSchoolContext context)
        {
            _context = context;
        }

        public Groupss()
        {
        }

        public async Task<List<Entities.Entities.Groups>> getListGroupsDAL()
        {
            return await _context.Groups.Select(x => x).ToListAsync();
        }

        public async Task<bool> addGroupDAL(Entities.Entities.Groups Groups)
        {
            try
            {
                var resGrouplist = await _context.Groups.Select(x => x).ToListAsync();
                foreach (var item in resGrouplist)
                {
                    if (item.rankGroup == Groups.rankGroup)
                    {
                        return false;
                    }
                }
                var resGroup = _context.Groups.AddAsync(Groups);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

       

        public async Task<bool> UpdateALLGroupDAL(GroupDto Groups)
        {
            try
            {
                var resGroup = await _context.Groups.Where(x => x.GroupsId==Groups.GroupsId).FirstOrDefaultAsync();
                resGroup.GroupName = Groups.GroupName;
                resGroup.rankGroup = Groups.rankGroup;
                //var resGroupEnd = _context.Groups.AddAsync(resGroup);
              await  _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Entities.Entities.Groups> getGroupAccordingToIDDAL(decimal GroupID)
        {
            return await _context.Groups.Where(x => x.GroupsId.Equals(GroupID)).FirstOrDefaultAsync();
        }

        public async Task<Entities.Entities.Groups> getGroupAccordingTorankGroupDAL(decimal rankGroup)
        {
            return await _context.Groups.Where(x => x.rankGroup.Equals(rankGroup)).FirstOrDefaultAsync();
    
        }
        public async Task<decimal?> getMaxrankGroupDAL()
        {
            var x =  _context.Groups.Max(x => x.rankGroup);
            return x;
        }

        public async Task<bool> deleteGroupDAL(decimal GroupID)
        {
            try
            {
                var group = await _context.Groups.Where(x => x.GroupsId.Equals(GroupID)).FirstOrDefaultAsync();
                _context.Groups.Remove(group);
                var isOk = await _context.SaveChangesAsync() >= 0;
                if (isOk)
                {
                }
                else
                {
                }

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
