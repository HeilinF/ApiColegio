using ApiColegio.Dtos.StudentDtos;
using AutoMapper;
using Domain.Entities.Models;

namespace ApiColegio.Mapping
{
    public class StudentProfile: AutoMapper.Profile
    {
        public StudentProfile()
        {

            CreateMap<Student, StudentToListDto>()
                .ForMember(x => x.Age, s => s.MapFrom(x => x.Age))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.NameBuilder()));

        }
    }

    
}
