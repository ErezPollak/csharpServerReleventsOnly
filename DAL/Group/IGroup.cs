using DAL.A_DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Group
{
    public interface IGroup
    {
        public Task<bool> addGroupDAL(Entities.Entities.Groups Groups);
        public Task<bool> UpdateALLGroupDAL(GroupDto Groups);
        public Task<List<Entities.Entities.Groups>> getListGroupsDAL();
        public Task<Entities.Entities.Groups> getGroupAccordingToIDDAL(decimal GroupID);
        public Task<Entities.Entities.Groups> getGroupAccordingTorankGroupDAL(decimal rankGroup);
        public Task<decimal?> getMaxrankGroupDAL();
        public Task<bool> deleteGroupDAL(decimal GroupID);
    }
}
