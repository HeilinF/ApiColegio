
using Application.Dtos.CourseDtos;
using AutoMapper;
using Domain.Entities.Models;

namespace Application.Mapping
{
    public class CourseProfile: Profile
    {
        public CourseProfile()
        {
            CreateMap<Course, CourseResponse>();
                
        }
    }
}
