using ApiColegio.Dtos.StudentDtos;
using ApiColegio.Models;
using AutoMapper;

namespace ApiColegio.Mapping
{
    public class StudentProfile: AutoMapper.Profile
    {
        public readonly IMapper _mapper;
        public StudentProfile(IMapper mapper)
        {
            _mapper = mapper;

            CreateMap<Student, StudentToListDto>()
                .ForMember(x => x.Age, s => s.MapFrom(x => x.Age))
                .ReverseMap() ;

        }

      
      public void q()
        {

            var e = new Student() { };
            _mapper.Map<Student, StudentToListDto>(e);
        }
    }

    
}
