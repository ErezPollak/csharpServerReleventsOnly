using AutoMapper;
using DAL.A_DTO;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Profiles
{
    class CoursesMP:Profile
    {
        public CoursesMP()
        {
            CreateMap<Course, coursDTO>();
            CreateMap<coursDTO, Course>();
        }
    }
}
