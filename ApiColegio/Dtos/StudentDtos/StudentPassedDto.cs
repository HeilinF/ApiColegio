using ApiColegio.Context;
using ApiColegio.Models;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.Data.SqlClient;
using System.Linq;

namespace ApiColegio.Dtos.StudentDtos
{
    public class StudentPassedDto
    {
        //public StudentPassedDto() { }

        
      //  public readonly int Id ;
        public string Name { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public double Average { get; set; }

        //public double GetAverage(StudentPassedDto student)
        //{
        //    Average = context.Grades
        //        .Where(x => x.IdStudent
        //        == student.Id).Select(x => x.FirstPartial).Average();

        //    return Average;
        //}
    }

    public class StudentCoursePassedDto
    {
        public int IdCourse { get; set; }
            public string Name { get; set; } = null!;
        public bool Passed { get; set; }

        public IEnumerable<StudentPassedDto> Student { get; set; } = null!;

        //public bool IsPassed()
        //{
        //    var student = new StudentPassedDto();

        //    if(student.GetAverage(student)>=6.5)
        //    return Passed=true;

        //    else { return Passed=false; }
        //}
    }
}
