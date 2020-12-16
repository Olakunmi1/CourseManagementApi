using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.Profiles
{
    public class CourseProfile : Profile
    {
        public CourseProfile()
        {
            CreateMap<Entities.Course, ReadDTO.CoursesDTO>();
            //.ForMember(dest => dest.AuthorName,
            //opt => opt.MapFrom(src => src.AuthorId));

            CreateMap<WriteDTO.createCourseForAuthorDTOW, Entities.Course>();

            CreateMap<WriteDTO.CourseForUpdateDTO, Entities.Course>();
            CreateMap<Entities.Course, WriteDTO.CourseForUpdateDTO>();
        }
    }
} 
