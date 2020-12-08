using AutoMapper;
using CourseApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseApi.Profiles
{
    //this class serves aas a configuration for our profiles in AutoMapper
    public class AuthorsProfile : Profile
    {
        //we need to specifically tell Automapper how to map between our entity and DTOs
        public AuthorsProfile()
        {
           
            //but we need to ensure the firstName,
            //LastName and DateofBirth for Age propety is mapped as per AutoMapper only maps property names dt exists,
            //so we call the "ForMember" method and "MapFrom"for Projection
            CreateMap<Entities.Author, ReadDTO.AuhtorDTO>()
                .ForMember(dest => dest.Name, 
                opt => opt.MapFrom(src => $"{ src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => DateTimeOffSetExtensions.GetCurrentAge(src.DateOfBirth)));

            CreateMap<WriteDTO.AuthorDTOW, Entities.Author>();
        }
    }
}
