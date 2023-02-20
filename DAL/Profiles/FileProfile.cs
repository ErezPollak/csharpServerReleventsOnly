using AutoMapper;
using DAL.A_DTO;
using Entities.Entities;

namespace DAL.Profiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<LearningFile, FileDTO>();
            CreateMap<FileDTO, LearningFile>();
        }
    }
}