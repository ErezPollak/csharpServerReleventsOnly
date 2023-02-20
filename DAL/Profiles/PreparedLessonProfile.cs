using AutoMapper;
using DAL.A_DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Profiles
{
    class PreparedLessonProfile: Profile
    {
        public PreparedLessonProfile()
        {
            CreateMap<PreparedLesson, PreparedLessonDTO>();
            CreateMap<PreparedLessonDTO, PreparedLesson>();
        }
    }
}
