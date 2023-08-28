using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using interrapidisimo.Dto;
using interrapidisimo.Models;

namespace interrapidisimo
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
    {
        CreateMap<Subject, SubjectDto>().ForMember(dest => dest.TeacherName,
                opt => opt.MapFrom(src => src.Teacher.FullName));
    }
    }
}