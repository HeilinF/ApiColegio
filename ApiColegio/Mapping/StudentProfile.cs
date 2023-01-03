
using Application.Dtos.StudentDtos;
using AutoMapper;
using Domain.Entities.Models;

namespace Application.Mapping
{
    public class StudentProfile: Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentResponse>()
                .ForMember(x => x.StudentId, s => s.MapFrom(x => x.Id))
                .ForMember(x => x.Age, s => s.MapFrom(x => x.Age))
                .ForMember(x => x.Course, s => s.MapFrom(x => x.Course))
                .ForMember(x => x.Name, s => s.MapFrom(x => x.NameBuilder()));
        }
    }

    
}
